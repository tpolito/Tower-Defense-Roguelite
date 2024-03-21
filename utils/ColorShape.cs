using Godot;

[Tool]
public partial class ColorShape : CollisionShape2D
{
  [Export]
  private Color _color = new Color(1, 1, 1, 1);

  public Color Color
  {
    get { return _color; }
    set
    {
      _color = value;
    }
  }

  public override void _Draw()
  {
    var offset = new Vector2(0, 0);

    if (Shape is CircleShape2D circleShape)
    {
      DrawCircle(offset, circleShape.Radius, _color);
    }
    else if (Shape is RectangleShape2D rectangleShape)
    {
      var rect = new Rect2(offset - rectangleShape.Size, rectangleShape.Size * 2.0f);
      DrawRect(rect, _color);
    }
    else if (Shape is CapsuleShape2D capsuleShape)
    {
      var upperCirclePosition = offset + new Vector2(0, capsuleShape.Height * 0.5f);
      DrawCircle(upperCirclePosition, capsuleShape.Radius, _color);

      var lowerCirclePosition = offset - new Vector2(0, capsuleShape.Height * 0.5f);
      DrawCircle(lowerCirclePosition, capsuleShape.Radius, _color);

      var rectPosition = offset - new Vector2(capsuleShape.Radius, capsuleShape.Height * 0.5f);
      var rect = new Rect2(rectPosition, new Vector2(capsuleShape.Radius * 2, capsuleShape.Height));
      DrawRect(rect, _color);
    }
  }
}