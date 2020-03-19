using Godot;
using System;

public class PlayerMoveState : PlayerState
{
    public override void Update(float delta)
    {
        var movement = GetMovementVector();

        Player.MoveAndCollide((movement * 200) * delta);
        
        if (movement == Vector2.Zero)
            StateMachine.ChangeState<PlayerIdleState>();
    }
}
