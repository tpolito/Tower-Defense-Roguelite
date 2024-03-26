extends Node2D
class_name BaseProjectile

@export var speed := 200.0

var target_position := Vector2.ZERO

func _ready() -> void:
    pass

func _process(delta: float) -> void:
  var dir := target_position - position
  dir = dir.normalized()
  var movement := dir * speed * delta
  
  global_position += movement