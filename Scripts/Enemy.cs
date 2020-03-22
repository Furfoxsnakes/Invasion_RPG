using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using InvasionRPG.Scripts.Enums;

public class Enemy : Battler
{
    public Navigation2D Nav;
    private List<Vector2> _path;
    public Player Player;
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
        Nav = GetNode<Navigation2D>("../../Nav");
        Player = GetNode<Player>("../Player");
        AggroRange = GetNode<Area2D>("AggroRange");
        AggroTime = GetNode<Timer>("AggroTime");
        AttackRange = GetNode<Area2D>("AttackRange");
        AttackRate = GetNode<Timer>("AttackRate");
        AttackRate.WaitTime = (60 / _attacksPerSeconds) / 60;

        Stats[StatTypes.MHP] = 20;
        Stats[StatTypes.HP] = Stats[StatTypes.MHP];
        Stats[StatTypes.EXP] = 10;
        
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
