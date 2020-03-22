using Godot;
using System;
using System.Linq;
using InvasionRPG.Scripts.Enums;

public class EnemyChaseState : EnemyState
{
    public override void Update(float delta)
    {
        var direction = (Target.Position - Enemy.Position).Normalized();
        Enemy.MoveAndSlide(direction * 50);

        if (AttackRange.OverlapsBody(Target))
            StateMachine.ChangeState<EnemyAttackState>(StateTypes.Enemy);
    }

    public override void Enter()
    {
        base.Enter();
        Enemy.AggroTime.Stop();
    }

    protected override void OnBodyExitedAggroRange(Battler battler)
    {
        if (battler != Target) return;

        Enemy.AggroTime.Start();
    }

    protected override void ConnectSignals()
    {
        base.ConnectSignals();
        Enemy.AggroTime.Connect("timeout", this, nameof(OnAggroTimeTimeout));
    }

    protected override void DisconnectSignals()
    {
        base.DisconnectSignals();
        Enemy.AggroTime.Disconnect("timeout", this, nameof(OnAggroTimeTimeout));
    }

    private void OnAggroTimeTimeout()
    {
        StateMachine.ChangeState<EnemyIdleState>(StateTypes.Enemy);
    }
}
