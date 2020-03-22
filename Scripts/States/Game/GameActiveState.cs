using Godot;
using System;
using InvasionRPG.Scripts.Enums;

public class GameActiveState : GameState
{
    public override void Enter()
    {
        GetTree().Paused = false;
    }

    public override void HandleInput(InputEvent inputEvent)
    {
        base.HandleInput(inputEvent);
        
        if (inputEvent is InputEventKey key && key.Pressed)
            if (Input.IsActionPressed("ui_cancel"))
                StateMachine.ChangeState<GamePausedState>(StateTypes.Game);
    }
}
