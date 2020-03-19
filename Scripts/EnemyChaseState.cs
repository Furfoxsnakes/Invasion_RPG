using Godot;
using System;
using System.Linq;

public class EnemyChaseState : EnemyState
{
    public override void Update(float delta)
    {
        var direction = (Target.Position - Enemy.Position).Normalized();
        Enemy.MoveAndSlide(direction * 50);
    }
}
