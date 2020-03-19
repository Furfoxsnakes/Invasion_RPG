using Godot;
using System;

public class WeaponIdleState : WeaponState
{
    public override void HandleInput(InputEvent inputEvent)
    {
        base.HandleInput(inputEvent);
        
        if (inputEvent is InputEventMouseButton button)
            if (button.Pressed) StateMachine.ChangeState<WeaponFiringState>();
    }
}
