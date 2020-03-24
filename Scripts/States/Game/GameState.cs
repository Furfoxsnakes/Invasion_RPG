using Godot;
using System;

public class GameState : State
{
    protected GameController Game => Parent as GameController;
    protected StateMachine StateMachine => Game.StateMachine;
    protected Container UIContainer => Parent.GetNode<Container>("GameUI/GameStateContainer");
    protected Label GameStateLabel => UIContainer.GetNode<Label>("GameStateLabel");
    protected Button RestartButton => UIContainer.GetNode<Button>("RestartButton");
    protected Button SaveGameButton => UIContainer.GetNode<Button>("SaveButton");
    protected Button LoadGameButton => UIContainer.GetNode<Button>("LoadButton");
    protected Button QuitButton => UIContainer.GetNode<Button>("QuitButton");

    protected bool IsGamePaused
    {
        get => GetTree().Paused;
        set => GetTree().Paused = value;
    }
}
