extends Node2D
class_name EnemySpawner

var enemy: PackedScene = preload ("res://entities/enemy/BaseEnemy.tscn")

@export var enemies_to_spawn := 10
@export var spawn_interval := 1.0

@onready var enemy_path: Path2D = $EnemyPath

var enemies_spawned := 0
var spawn_timer: Timer

func _ready() -> void:
  spawn_timer = Timer.new()
  spawn_timer.wait_time = spawn_interval
  spawn_timer.autostart = true
  add_child(spawn_timer)
  spawn_timer.timeout.connect(_on_Timer_timeout)
  spawn_timer.start()

func spawn_enemy() -> void:
  var enemy_instance: PathFollow2D = enemy.instantiate()
  enemies_spawned += 1
  enemy_instance.name = "Enemy" + str(enemies_spawned)
  enemy_path.add_child(enemy_instance)

func _on_Timer_timeout() -> void:
  if enemies_spawned < enemies_to_spawn:
    spawn_enemy()
  else:
    spawn_timer.stop()