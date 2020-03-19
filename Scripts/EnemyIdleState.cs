using Godot;
using System;

public class EnemyIdleState : EnemyState
{
    protected override void OnBodyEnteredAggroRange(Battler battler)
    {
        if (!(battler is Player player)) return;
        
        Target = player;
        StateMachine.ChangeState<EnemyChaseState>();
    }
}