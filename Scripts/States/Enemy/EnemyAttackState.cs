using Godot;
using System;
using InvasionRPG.Scripts.Enums;

public class EnemyAttackState : EnemyState
{
    public override void Update(float delta)
    {
        if (!AttackRange.OverlapsBody(Target))
            StateMachine.ChangeState<EnemyChaseState>(StateTypes.Enemy);

        if (Enemy.AttackRate.IsStopped())
        {
            Enemy.Attack(Target);
            Enemy.AttackRate.Start();
        }
    }
}
