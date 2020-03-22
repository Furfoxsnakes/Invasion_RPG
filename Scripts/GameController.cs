using Godot;
using System;
using InvasionRPG.Scripts.Enums;

public class GameController : Node
{
    public StateMachine StateMachine;
    [Export] private NodePath _battlersPath;
    public static Player Player;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        StateMachine = GetNode<StateMachine>("StateMachine");
        StateMachine.ChangeState<GameActiveState>(StateTypes.Game);
        Player = GetNode(_battlersPath).GetNode<Player>("Player");
    }
}
