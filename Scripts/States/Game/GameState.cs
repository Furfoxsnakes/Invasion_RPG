using Godot;
using System;

public class GameState : State
{
    protected GameController Game => Parent as GameController;
    protected StateMachine StateMachine => Game.StateMachine;
    protected Container UIContainer => Parent.GetNode<Container>("GameUI/GameStateContainer");
    protected Label GameStateLabel => UIContainer.GetNode<Label>("GameStateLabel");
    protected Button NewGameButton => UIContainer.GetNode<Button>("NewGameButton");
    protected Button RestartButton => UIContainer.GetNode<Button>("RestartButton");
    protected Button SaveGameButton => UIContainer.GetNode<Button>("SaveButton");
    protected Button QuitButton => UIContainer.GetNode<Button>("QuitButton");
    protected GameData GameData => GetTree().Root.GetNode<GameData>("GameData");
    protected PlayerDataModel PlayerData => GameData.PlayerData;

    protected bool IsGamePaused
    {
        get => GetTree().Paused;
        set => GetTree().Paused = value;
    }
}
