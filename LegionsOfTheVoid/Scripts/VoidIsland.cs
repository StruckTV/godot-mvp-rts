using Godot;
using System;

public partial class VoidIsland : Control
{
    public override void _Ready()
    {
        // Connect the button signal
        GetNode<Button>("StartRaidButton").Pressed += OnStartRaidPressed;
    }

    private void OnStartRaidPressed()
    {
        // Switch to the Extraction Ops scene
        GetTree().ChangeSceneToFile("res://Scenes/ExtractionOps.tscn");
    }
}
