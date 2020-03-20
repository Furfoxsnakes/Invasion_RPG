using Godot;
using System;
using System.Diagnostics;

public class EnemyState : State
{
    protected Enemy Enemy => Parent as Enemy;
    protected Player Player => Enemy.Player;

    protected Battler Target
    {
        get => Enemy.Target;
        set => Enemy.Target = value;
    }
    protected Area2D AggroRange => Enemy.AggroRange;
    protected Area2D AttackRange => Enemy.AttackRange;
    protected NewStateMachine StateMachine => Enemy.StateMachine;

    protected Vector2 Pos
    {
        get => Enemy.Position;
        set => Enemy.Position = value;
    }
    protected float DistanceToPlayer => Enemy.Position.DistanceTo(Player.Position);
    protected Navigation2D Nav => Enemy.Nav;

    protected override void ConnectSignals()
    {
        var error = AggroRange.Connect("body_entered", this, nameof(OnBodyEnteredAggroRange));
        AggroRange.Connect("body_exited", this, nameof(OnBodyExitedAggroRange));
        GD.Print(error);
    }

    protected override void DisconnectSignals()
    {
        AggroRange.Disconnect("body_entered", this, nameof(OnBodyEnteredAggroRange));
        AggroRange.Disconnect("body_exited", this, nameof(OnBodyExitedAggroRange));
    }

    protected virtual void OnBodyEnteredAggroRange(Battler battler)
    {
        
    }

    protected virtual void OnBodyExitedAggroRange(Battler battler)
    {
        
    }
}
