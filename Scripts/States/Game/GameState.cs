using Godot;
using System;

public class GameState : State
{
    protected GameController Game => Parent as GameController;
    protected StateMachine StateMachine => Game.StateMachine;
    protected Container UIContainer => Parent.GetNode<Container>("GameUI/GameStateContainer");
    protected Label GameStateLabel => UIContainer.GetNode<Label>("GameStateLabel");
    protected Button RestartButton => UIContainer.GetNode<Button>("RestartButton");
    protected Button QuitButton => UIContainer.GetNode<Button>("QuitButton");

    protected bool IsGamePaused
    {
        get => GetTree().Paused;
        set => GetTree().Paused = value;
    }

    protected override void ConnectSignals()
    {
        base.ConnectSignals();
        QuitButton.Connect("pressed", this, nameof(OnQuitButtonPressed));
        RestartButton.Connect("pressed", this, nameof(OnRestartButtonPressed));
    }

    protected virtual void OnQuitButtonPressed()
    {
        GetTree().Quit();
    }

    protected virtual void OnRestartButtonPressed()
    {
        GetTree().ReloadCurrentScene();
    }
}
