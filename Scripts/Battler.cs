using Godot;
using System.Collections.Generic;
using InvasionRPG.Scripts.Enums;

public class Battler : KinematicBody2D
{
    public StateMachine StateMachine;
    public Stats Stats;
    protected GameController GameController => GetTree().Root.GetNode<GameController>("Game");
    protected List<Battler> DamageSources = new List<Battler>();

    public override void _Ready()
    {
        Stats = GetNode<Stats>("Stats");
        StateMachine = GetNode<StateMachine>("StateMachine");
    }

    public void TakeDamage(int amount, Battler source)
    {
        if (!DamageSources.Contains(source))
            DamageSources.Add(source);
        
        Stats[StatTypes.HP] -= amount;
        
        if (Stats[StatTypes.HP] <= 0)
            Die();
    }

    public virtual void Die()
    {
        //QueueFree();
    }
}
