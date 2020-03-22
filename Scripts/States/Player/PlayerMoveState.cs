using Godot;
using System;
using InvasionRPG.Scripts.Enums;

public class PlayerMoveState : PlayerState
{
    public override void Update(float delta)
    {
        var movement = GetMovementVector();

        Player.MoveAndCollide((movement * 200) * delta);
        
        if (movement == Vector2.Zero)
            StateMachine.ChangeState<PlayerIdleState>(StateTypes.Player);
    }
}
