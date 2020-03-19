using Godot;
using System;

public class Player : Battler
{
    [Export] private NodePath _playerCamera;

    public override void _Ready()
    {
        base._Ready();
        StateMachine.ChangeState<PlayerIdleState>();
    }
}
