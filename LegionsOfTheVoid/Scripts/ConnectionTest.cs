using Godot;
using System;

public partial class ConnectionTest : Control
{
    private Label _statusLabel;
    private Button _retryButton;
    private Button _mainMenuButton;

    public override void _Ready()
    {
        _statusLabel = GetNode<Label>("Panel/VBoxContainer/StatusLabel");
        _retryButton = GetNode<Button>("Panel/VBoxContainer/RetryButton");
        _mainMenuButton = GetNode<Button>("Panel/VBoxContainer/MainMenuButton");

        _retryButton.Pressed += OnRetryPressed;
        _mainMenuButton.Pressed += OnMainMenuPressed;

        // Run test immediately
        RunTest();
    }

    private async void RunTest()
    {
        _statusLabel.Text = "Testing Connection...";
        _statusLabel.Modulate = Colors.Yellow;

        // Wait a moment for the NetworkManager to initialize if we just started
        await ToSignal(GetTree().CreateTimer(1.5f), "timeout");

        var nm = NetworkManager.Instance;

        if (nm == null)
        {
            SetStatus("FAIL: NetworkManager Instance is null.", Colors.Red);
            return;
        }

        if (nm.Client == null)
        {
            SetStatus("FAIL: Nakama Client is not initialized.", Colors.Red);
            return;
        }

        if (nm.Session == null)
        {
            SetStatus("FAIL: Session is null. Authentication failed.\nCheck server logs.", Colors.Red);
            return;
        }

        if (nm.Socket == null || !nm.Socket.IsConnected)
        {
            SetStatus("FAIL: Socket is not connected.\nCheck port 7350/7351.", Colors.Red);
            return;
        }

        SetStatus($"PASS: Connected as {nm.Session.Username}\nID: {nm.Session.UserId}", Colors.Green);
    }

    private void SetStatus(string text, Color color)
    {
        _statusLabel.Text = text;
        _statusLabel.Modulate = color;
    }

    private void OnRetryPressed()
    {
        // Reloading the scene won't restart NetworkManager (it's autoload).
        // But running the test logic again checks the current state.
        RunTest();
    }

    private void OnMainMenuPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/VoidIsland.tscn");
    }
}
