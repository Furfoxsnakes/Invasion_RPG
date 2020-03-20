using Godot;
using System;
using InvasionRPG.Scripts.Enums;

public class Battler : KinematicBody2D
{
    public NewStateMachine StateMachine;
    public Stats Stats;
    
    public override void _Ready()
    {
        Stats = GetNode<Stats>("Stats");
        StateMachine = GetNode<NewStateMachine>("StateMachine");
    }

    public void TakeDamage(int amount)
    {
        Stats[StatTypes.HP] -= amount;
    }
}
