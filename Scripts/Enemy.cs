using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using InvasionRPG.Scripts.Enums;

public class Enemy : Battler
{
    public ArenaController Arena;
    private List<Vector2> _path;
    public Area2D AggroRange;
    public Timer AggroTime;
    public Area2D AttackRange;
    public Battler Target;
    public static readonly string EnemyDidDieNotification = "Enemy.DidDie";
    
    [Export] private float _attacksPerSeconds = 1;
    public Timer AttackRate;

    public override void _Ready()
    {
        base._Ready();

        // Assign nodes/components
        Arena = GameController.GetNode<ArenaController>("Arena");
        AggroRange = GetNode<Area2D>("AggroRange");
        AggroTime = GetNode<Timer>("AggroTime");
        AttackRange = GetNode<Area2D>("AttackRange");
        AttackRate = GetNode<Timer>("AttackRate");
        AttackRate.WaitTime = (60 / _attacksPerSeconds) / 60;

        Stats.SetValue(StatTypes.MHP, 20, false);
        Stats.SetValue(StatTypes.HP, Stats[StatTypes.MHP], false);
        Stats.SetValue(StatTypes.EXP, 10000, false);
        
        StateMachine.ChangeState<EnemyIdleState>(StateTypes.Enemy);
    }

    public void Attack(Battler battler)
    {
        battler.TakeDamage(5, this);
    }

    public override void Die()
    {
        this.PostNotification(EnemyDidDieNotification, DamageSources);
        StateMachine.CurrentState.Exit();
        QueueFree();
    }
}
