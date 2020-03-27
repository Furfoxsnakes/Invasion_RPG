using Godot;
using System;

public class GameOverState : GameState
{
    public override void Enter()
    {
        IsGamePaused = true;
        GameStateLabel.Text = "GAME OVER";
        UIContainer.Visible = true;
        QuitButton.Visible = true;
        RestartButton.Visible = true;
        Game.Save();
    }
}
