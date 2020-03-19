using Godot;
using System;

public class PlayerCamera : Camera2D
{
    public override void _Process(float delta)
    {
        var mousePos = GetGlobalMousePosition();
        var targetPos = GetParent<Node2D>().GlobalPosition;
        GlobalPosition = targetPos.LinearInterpolate(mousePos, 0.25f);
    }
}
