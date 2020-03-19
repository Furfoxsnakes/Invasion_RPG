using Godot;
using System;

public class PlayerIdleState : PlayerState
{
    public override void Update(float delta)
    {
        var movement = GetMovementVector();
        
        if (movement != Vector2.Zero)
            StateMachine.ChangeState<PlayerMoveState>();
    }
}
