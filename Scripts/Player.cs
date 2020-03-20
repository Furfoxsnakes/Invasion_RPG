using Godot;
using System;
using InvasionRPG.Scripts.Enums;

public class Player : Battler
{
    [Export] private NodePath _playerCamera;

    public override void _Ready()
    {
        base._Ready();
        Stats[StatTypes.HP] = 100;
        StateMachine.ChangeState<PlayerIdleState>();
    }
}
