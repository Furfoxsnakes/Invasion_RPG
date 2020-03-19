using Godot;
using System;

public class Battler : KinematicBody2D
{
    public NewStateMachine StateMachine;
    
    public override void _Ready()
    {
        StateMachine = GetNode<NewStateMachine>("StateMachine");
    }
}
