using Godot;
using System;

public class PlayerState : State
{
    protected Player Player => Parent as Player;
    protected StateMachine StateMachine => Player.StateMachine;

    public Vector2 GetMovementVector()
    {
        var movement = Vector2.Zero;

        movement.x = Convert.ToInt32(Input.IsActionPressed("move_right")) -
                     Convert.ToInt32(Input.IsActionPressed("move_left"));
        movement.y = Convert.ToInt32(Input.IsActionPressed("move_down")) -
                     Convert.ToInt32(Input.IsActionPressed("move_up"));

        return movement;
    }
}
