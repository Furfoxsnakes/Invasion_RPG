using Godot;
using System;

public class GameState : State
{
    protected GameController Game => Parent as GameController;
}
