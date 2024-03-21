using Godot;
using System;

public partial class BaseUnit : Node2D
{
  private Area2D AggroArea;
  private PathFollow2D currentTarget;
  private Timer attackTimer;
  private Tween _tween;
  private Vector2 _originalScale;

  [Export]
  public int AggroRange { get; set; } = 100;

  public override void _Ready()
  {
    // On Ready
    AggroArea = GetNode<Area2D>("AggroArea");
    AggroArea.GetChild<CollisionShape2D>(0).Shape = new CircleShape2D { Radius = AggroRange };
    AggroArea.AreaEntered += OnAggroAreaAreaEntered;
    AggroArea.AreaExited += OnAggroAreaAreaExited;

    // Attack Timer
    attackTimer = new Timer
    {
      WaitTime = .75f,
      Autostart = false
    };
    AddChild(attackTimer);
    attackTimer.Timeout += OnAttackTimerTimeout;

    // Tween
    // TOOD: Add tween for attack animation
  }


  public void OnAggroAreaAreaEntered(Node area)
  {
    currentTarget ??= area.GetParent<BaseEnemy>();
    Attack(); // Initial attack
    attackTimer.Start();
  }

  public void OnAggroAreaAreaExited(Node area)
  {
    if (area.GetParent<BaseEnemy>() == currentTarget)
    {
      currentTarget = null;
    }
  }

  public void OnAttackTimerTimeout()
  {
    if (currentTarget != null)
    {
      Attack();
    }
  }

  public void Attack()
  {
    GD.Print("Attacking ", currentTarget.Name);
    attackTimer.Start();
  }
}
