extends Node2D
class_name BaseUnit

@onready var aggro_area := $AggroArea as Area2D

var projectile_scene: PackedScene = preload ("res://entities/projectiles/base_projectile/BaseProjectile.tscn")
var target_list: Array[PathFollow2D] = []
var current_target: PathFollow2D
var attack_timer: Timer

func _ready() -> void:
  aggro_area.area_entered.connect(_on_aggro_area_entered)
  aggro_area.area_exited.connect(_on_aggro_area_exited)

  attack_timer = Timer.new()
  attack_timer.wait_time = 0.75;
  attack_timer.autostart = false;
  add_child(attack_timer)
  attack_timer.timeout.connect(_on_attack_timer_timeout)

func _on_aggro_area_entered(area: Area2D) -> void:
  target_list.append(area.get_parent())
  if current_target == null:
    current_target = target_list[0]

func _on_aggro_area_exited(area: Area2D) -> void:
  target_list.erase(area.get_parent())

  if target_list.size() == 0:
    current_target = null
  else:
    current_target = target_list[0]

func _on_attack_timer_timeout() -> void:
  if current_target != null:
    attack()

func attack() -> void:
  var projectile_instance: BaseProjectile = projectile_scene.instantiate()
  projectile_instance.target_position = current_target.global_position

  add_child(projectile_instance)
  attack_timer.start()