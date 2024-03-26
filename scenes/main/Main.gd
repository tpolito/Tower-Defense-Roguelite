extends Node2D
class_name Main

var game_scene: PackedScene = preload ("res://scenes/game/Game.tscn")

func _ready() -> void:
  var game_instance: Node2D = game_scene.instantiate()
  add_child(game_instance)

func _unhandled_input(event: InputEvent) -> void:
  if event is InputEventKey and event.is_pressed():
    if event.scancode == KEY_ESCAPE:
      get_tree().quit()
    if event.scancode == KEY_R:
      get_tree().reload_current_scene()
