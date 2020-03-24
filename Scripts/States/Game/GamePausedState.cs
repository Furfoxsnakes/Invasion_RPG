using Godot;
using System;
using InvasionRPG.Scripts.Enums;

public class GamePausedState : GameState
{
    public override void Enter()
    {
        GetTree().Paused = true;
        GameStateLabel.Text = "PAUSED";
        UIContainer.Visible = true;
        SaveGameButton.Visible = true;
    }

    public override void HandleInput(InputEvent inputEvent)
    {
        if (inputEvent is InputEventKey key)
            if (Input.IsActionPressed("ui_cancel"))
                StateMachine.ChangeState<GameActiveState>(StateTypes.Game);
    }
}
