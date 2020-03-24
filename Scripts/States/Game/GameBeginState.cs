using Godot;
using System;

public class GameBeginState : GameState
{
    public override void Enter()
    {
        base.Enter();
        IsGamePaused = true;
        GameStateLabel.Text = "NEW GAME";
        RestartButton.Visible = false;
        SaveGameButton.Visible = false;
        UIContainer.Visible = true;
    }
}
