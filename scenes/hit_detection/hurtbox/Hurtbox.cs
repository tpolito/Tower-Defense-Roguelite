using Godot;
using System;

[GlobalClass]
public partial class Hurtbox : Area2D
{
  [Signal]
  public delegate void HitEventHandler(int damage);

  public override void _Ready()
  {
    AreaEntered += OnHurtboxAreaEntered;
  }


  public void OnHurtboxAreaEntered(Area2D area)
  {
    if (area is Hitbox hitbox)
    {
      EmitSignal(SignalName.Hit, hitbox.damage);
    }
  }
}