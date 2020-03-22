using Godot;
using System;

public class GameState : State
{
    protected GameController Game => Parent as GameController;
    protected StateMachine StateMachine => Game.StateMachine;
    protected Label GameStateLabel => Parent.GetNode<Label>("GameUI/Container/GameStateLabel");
    protected Button RestartButton => Parent.GetNode<Button>("GameUI/Container/RestartButton");
    protected Button QuitButton => Parent.GetNode<Button>("GameUI/Container/QuitButton");
    protected Container UIContainer => Parent.GetNode<Container>("GameUI/Container");

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
