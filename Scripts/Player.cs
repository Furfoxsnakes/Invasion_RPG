using Godot;
using System;
using System.Collections.Generic;
using InvasionRPG.Scripts.Enums;

public class Player : Battler
{
    [Export] private NodePath _playerCamera;

    public override void _EnterTree()
    {
        base._EnterTree();
        this.AddObserver(OnEnemyDidDie, Enemy.EnemyDidDieNotification);
    }

    public override void _ExitTree()
    {
        base._ExitTree();
        this.RemoveObserver(OnEnemyDidDie, Enemy.EnemyDidDieNotification);
    }

    private void OnEnemyDidDie(object sender, object args)
    {
        var enemy = sender as Enemy;
        var damageSources = args as List<Battler>;
        var enemyStats = enemy.Stats;
        
        if (damageSources.Contains(this))
            GD.Print($"{Name} receives {enemyStats[StatTypes.EXP]} XP!");
    }

    public override void _Ready()
    {
        base._Ready();
        Stats[StatTypes.MHP] = 100;
        Stats[StatTypes.HP] = Stats[StatTypes.MHP];
        StateMachine.ChangeState<PlayerIdleState>(StateTypes.Player);
    }

    public override void Die()
    {
        GameController.StateMachine.ChangeState<GameOverState>(StateTypes.Game);
    }
}
