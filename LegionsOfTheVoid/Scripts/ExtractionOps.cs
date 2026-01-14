using Godot;
using System;

public partial class ExtractionOps : Node3D
{
    private Label _threatLabel;
    private double _timeElapsed = 0;
    private int _threatLevel = 1;

    public override void _Ready()
    {
        _threatLabel = GetNode<Label>("CanvasLayer/ThreatLabel");
        GetNode<Button>("CanvasLayer/ExtractButton").Pressed += OnExtractPressed;
    }

    public override void _Process(double delta)
    {
        _timeElapsed += delta;

        // Simple Threat Level Logic based on GDD
        // Level 1: 0-10 mins (0-600s)
        // Level 2: 10-20 mins (600-1200s)
        // Level 3: 20-30 mins (1200-1800s)
        // Level 4: 30+ mins (1800+s)

        // Accelerated for MVP testing: 1 minute = 1 level
        if (_timeElapsed < 60) _threatLevel = 1;
        else if (_timeElapsed < 120) _threatLevel = 2;
        else if (_timeElapsed < 180) _threatLevel = 3;
        else _threatLevel = 4;

        _threatLabel.Text = $"Threat Level: {_threatLevel}\nTime: {_timeElapsed:F1}s";
    }

    private void OnExtractPressed()
    {
        GD.Print("Extracting...");
        // Return to Void Island
        GetTree().ChangeSceneToFile("res://Scenes/VoidIsland.tscn");
    }
}
