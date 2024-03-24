using Godot;
using System;

public partial class BaseProjectile : Node2D
{
  [Export]
  public float ProjectileSpeed { get; set; } = 200f;
  private Vector2 _targetPosition;
  public override void _Ready()
  {
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta)
  {
    Vector2 dir = _targetPosition - GlobalPosition;
    dir = dir.Normalized();
    Vector2 movement = dir * ProjectileSpeed * (float)delta;

    GlobalPosition += movement;
  }
}
