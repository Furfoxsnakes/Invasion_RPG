using Godot;
using System;

public class EnemyAttackState : EnemyState
{
    public override void Update(float delta)
    {
        if (!AttackRange.OverlapsBody(Target))
            StateMachine.ChangeState<EnemyChaseState>();

        if (Enemy.AttackRate.IsStopped())
        {
            Enemy.Attack(Target);
            Enemy.AttackRate.Start();
        }
    }
}
