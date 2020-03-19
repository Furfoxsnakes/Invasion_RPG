using Godot;
using System;

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
        AggroRange.Connect("body_entered", this, nameof(OnBodyEnteredAggroRange));
    }

    protected override void DisconnectSignals()
    {
        AggroRange.Disconnect("body_entered", this, nameof(OnBodyEnteredAggroRange));
    }

    protected virtual void OnBodyEnteredAggroRange(Battler battler)
    {
        
    }
}
