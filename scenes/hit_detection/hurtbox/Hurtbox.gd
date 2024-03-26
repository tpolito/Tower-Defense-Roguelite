extends Area2D
class_name HurtboxComponent

signal hit(damage: int)

func _ready() -> void:
  area_entered.connect(_on_hurtbox_area_entered)

func _on_hurtbox_area_entered(area: Area2D) -> void:
  if area.has_method("get_damage"):
    emit_signal("hit", area.get_damage())