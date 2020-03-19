using Godot;
using System;

public class PlayerState : State
{
    protected Player Player => Parent as Player;
    protected NewStateMachine StateMachine => Player.StateMachine;
    
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void HandleInput(InputEvent inputEvent)
    {
        
    }

    public override void Update(float delta)
    {
        
    }

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
