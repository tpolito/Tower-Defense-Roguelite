using Godot;
using System;


public partial class BaseEnemy : PathFollow2D
{
  private Label targetLabel;
  // Called when the node enters the scene tree for the first time.
  private Tween _tween;
  private const float RotationAng = Mathf.Pi / 10;
  public override void _Ready()
  {
    // On Ready
    targetLabel = GetNode<Label>("TargetLabel");
    // Tween
    _tween = CreateTween();
    _tween.SetLoops();
    _tween.TweenProperty(this, "rotation", RotationAng, 0.5f).SetTrans(Tween.TransitionType.Sine).SetEase(Tween.EaseType.InOut);
    _tween.TweenProperty(this, "rotation", -RotationAng, 0.5f).SetTrans(Tween.TransitionType.Sine).SetEase(Tween.EaseType.InOut);
    _tween.TweenProperty(this, "rotation", 0, 0.5f).SetTrans(Tween.TransitionType.Sine).SetEase(Tween.EaseType.InOut);
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta)
  {
    ProgressRatio += 0.001f;
    if (ProgressRatio == 1)
    {
      QueueFree();
    }
  }

  public void ToggleTarget()
  {
    targetLabel.Visible = !targetLabel.Visible;
  }
}
