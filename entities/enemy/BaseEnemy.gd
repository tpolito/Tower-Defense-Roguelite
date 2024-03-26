extends PathFollow2D
class_name BaseEnemy

@onready var hurtbox: Area2D = $Hurtbox

var tween: Tween
var rotation_ang := PI / 10;

func _ready() -> void:
  tween = get_tree().create_tween()
  tween.set_loops()
  tween.tween_property(self, "rotation", rotation_ang, 0.5).set_trans(Tween.TRANS_SINE).set_ease(Tween.EASE_IN_OUT)
  tween.tween_property(self, "rotation", -rotation_ang, 0.5).set_trans(Tween.TRANS_SINE).set_ease(Tween.EASE_IN_OUT)
  tween.tween_property(self, "rotation", 0, 0.5).set_trans(Tween.TRANS_SINE).set_ease(Tween.EASE_IN_OUT)

  hurtbox.hit.connect(_on_hurtbox_hit)

func _process(_delta: float) -> void:
  progress_ratio += 0.001
  if progress_ratio == 1:
    queue_free()

func _on_hurtbox_hit(damage: int) -> void:
  print("Enemy hit for ", damage)