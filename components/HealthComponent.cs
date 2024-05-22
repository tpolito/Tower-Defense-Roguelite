using Godot;
using System;

public partial class HealthComponent : Node
{
  [Export]
  public int MaxHealth { get; set; } = 10;

  private int currentHealth;

  public int CurrentHealth
  {
    get => currentHealth;
    set
    {
      currentHealth = Mathf.Clamp(value, 0, MaxHealth);
      if (currentHealth <= 0)
      {
        // Invoke event here
      }
    }
  }

  public override void _Ready()
  {
    currentHealth = MaxHealth;
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta)
  {
  }
}
