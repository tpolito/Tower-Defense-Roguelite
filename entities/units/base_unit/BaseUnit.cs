using Godot;
using System;
using System.Collections.Generic;

public partial class BaseUnit : Node2D
{
  private Area2D AggroArea;
  private PathFollow2D currentTarget;
  private readonly List<PathFollow2D> targetList = new();
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
    targetList.Add(area.GetParent<PathFollow2D>());
    currentTarget ??= targetList[0];
    Attack(); // Initial attack
    attackTimer.Start();
  }

  public void OnAggroAreaAreaExited(Node area)
  {
    targetList.Remove(area.GetParent<PathFollow2D>());
    if (targetList.Count == 0)
    {
      currentTarget = null;
    }
    else
    {
      currentTarget = targetList[0];
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
    var projectileScene = GD.Load<PackedScene>("res://entities/projectiles/base_projectile/BaseProjectile.tscn");
    var projectileInstance = projectileScene.Instantiate<BaseProjectile>();

    projectileInstance.Position = currentTarget.GlobalPosition;

    AddChild(projectileInstance);
    GD.Print("Attacking ", currentTarget.Name);
    attackTimer.Start();
  }
}
