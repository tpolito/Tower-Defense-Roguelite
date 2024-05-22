using Godot;
using System;
using System.Collections.Generic;

public partial class Entity : Node2D
{
  [Export]
  Vector2 startingAtlasPosition = new(0, 0);
  AnimatedSprite2D animatedSprite = new();
  SpriteFrames spriteFrames = new();

  readonly Random random = new();
  readonly List<string> animNames = new() { "idle", "walk", "attack", "hit", "die" };

  public override void _Ready()
  {
    GenerateAnimationFrames();
    animatedSprite.AnimationFinished += () => GD.Print("Finished");
    AddChild(animatedSprite);
    string randAnimName = animNames[random.Next(0, 4)];
    animatedSprite.Play(randAnimName);
  }

  private static string GetAnimationNameFromIndex(int index)
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
    animNames.ForEach((animName) =>
    {
      spriteFrames.AddAnimation(animName);
      spriteFrames.SetAnimationLoop(animName, true);
    });

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
  }
}
