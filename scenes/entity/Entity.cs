using Godot;
using System;

public partial class Entity : Node2D
{
  [Export]
  Vector2 startingAtlasPosition = new(0, 0);
  AnimatedSprite2D animatedSprite = new();
  SpriteFrames spriteFrames = new();
  public override void _Ready()
  {
    GenerateAnimationFrames();
    animatedSprite.Play("walk");
  }

  private string GetAnimationNameFromIndex(int index)
  {
    if (index >= 0 && index <= 3)
    {
      return "idle";
    }
    else if (index >= 4 && index <= 7)
    {
      return "walk";
    }
    else if (index >= 8 && index <= 11)
    {
      return "attack";
    }
    else if (index >= 12 && index <= 15)
    {
      return "hit";
    }
    else if (index >= 16 && index <= 19)
    {
      return "die";
    }
    else
    {
      return "idle";
    }
  }
  private void GenerateAnimationFrames()
  {
    spriteFrames.AddAnimation("idle");
    spriteFrames.SetAnimationLoop("idle", true);

    spriteFrames.AddAnimation("walk");
    spriteFrames.SetAnimationLoop("walk", true);

    spriteFrames.AddAnimation("attack");
    spriteFrames.SetAnimationLoop("attack", true);

    spriteFrames.AddAnimation("hit");
    spriteFrames.SetAnimationLoop("hit", true);

    spriteFrames.AddAnimation("die");
    spriteFrames.SetAnimationLoop("die", true);

    Vector2 textureSize = new(16, 16);
    Texture2D texture = GD.Load<Texture2D>("res://assets/AllUnitsSpriteSheet.png");

    for (int i = 0; i < 20; i++)
    {
      string animationName = GetAnimationNameFromIndex(i);
      AtlasTexture atlasTexture = new()
      {
        Atlas = texture,
        Region = new Rect2(startingAtlasPosition + new Vector2(i * textureSize.X, 0 * textureSize.Y), textureSize)
      };
      spriteFrames.AddFrame(animationName, atlasTexture);
    }
    animatedSprite.SpriteFrames = spriteFrames;
    AddChild(animatedSprite);
  }
}
