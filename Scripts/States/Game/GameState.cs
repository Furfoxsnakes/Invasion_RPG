using Godot;
using System;

public class GameState : State
{
    protected GameController Game => Parent as GameController;
    protected StateMachine StateMachine => Game.StateMachine;
    protected Label GameStateLabel => Parent.GetNode<Label>("GameUI/GameStateLabel");
    
}
