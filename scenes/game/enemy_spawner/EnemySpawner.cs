using Godot;
using System;

[GlobalClass]
public partial class EnemySpawner : Node2D
{
  // Called when the node enters the scene tree for the first time.
  private Timer timer;
  private Path2D enemyPath;


  [Export]
  public int EnemiesToSpawn { get; set; } = 10;
  [Export]
  public float SpawnInterval { get; set; } = 1.0f;
  int enemiesSpawned = 0;

  public override void _Ready()
  {
    // Timer
    timer = new Timer
    {
      WaitTime = SpawnInterval,
      Autostart = true
    };
    AddChild(timer);
    timer.Timeout += OnTimerTimeout;
    timer.Start();

    // Path
    enemyPath = GetNode<Path2D>("EnemyPath");
  }

  private void OnTimerTimeout()
  {
    if (enemiesSpawned == EnemiesToSpawn)
    {
      timer.Stop();
      return;
    }

    var enemy = GD.Load<PackedScene>("res://entities/enemy/BaseEnemy.tscn").Instantiate();
    enemiesSpawned++;
    enemy.Name = "Enemy " + enemiesSpawned;
    enemyPath.AddChild(enemy);
    GD.Print("Spawning enemy: ", enemiesSpawned, " out of ", EnemiesToSpawn);
  }

  private int CountEnemies()
  {
    var enemies = GetNode<Node2D>("EnemyPath").GetChildren();
    GD.Print(enemies.Count);
    return enemies.Count;
  }
}
