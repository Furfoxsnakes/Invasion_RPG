using Godot;
using System;
using System.Collections.Generic;
using InvasionRPG.Scripts.Enums;

public class Player : Battler
{
    [Export] private NodePath _playerCamera;
    public Rank Rank;

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
    
    public override void _Ready()
    {
        base._Ready();
        Rank = GetNode<Rank>("Rank");
        
        Stats.SetValue(StatTypes.MHP, 100, false);
        Stats.SetValue(StatTypes.HP, Stats[StatTypes.MHP], false);
        Rank.Init(1);
        StateMachine.ChangeState<PlayerIdleState>(StateTypes.Player);
        AddToGroup("Persist");
    }

    public override void Die()
    {
        GameController.StateMachine.ChangeState<GameOverState>(StateTypes.Game);
    }

    #region Notification handlers
    
    private void OnEnemyDidDie(object sender, object args)
    {
        var enemy = sender as Enemy;
        var damageSources = args as List<Battler>;
        var enemyStats = enemy.Stats;

        if (damageSources.Contains(this))
        {
            Stats[StatTypes.EXP] += enemyStats[StatTypes.EXP];
        }
    }
    
    public DataModel Save()
    {
        return new DataModel()
        {
            Filename = Filename,
            Parent = GetParent().GetPath(),
            Name = Name,
            Stats = Stats.Data
        };
    }

    #endregion
    
    
}
