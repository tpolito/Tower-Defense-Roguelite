using Godot;
using System;

public partial class Main : Node2D
{
  public override void _Ready()
  {
    // Instantiates the 'Game' scene and adds it as a child of the 'Main' scene.
    var game = GD.Load<PackedScene>("res://scenes/game/Game.tscn").Instantiate();
    AddChild(game);
  }

  public override void _Process(double delta)
  {
  }

  public override void _UnhandledInput(InputEvent @event)
  {
    if (@event is InputEventKey eventKey && eventKey.Pressed)
    {
      // Quit game on escape key press
      if (eventKey.Keycode == Key.Escape)
      {
        GetTree().Quit();
      }
      if (eventKey.Keycode == Key.R)
      {
        GetTree().ReloadCurrentScene();
      }
    }
  }
}
