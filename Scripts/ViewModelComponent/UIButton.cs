using Godot;
using System;

public class UIButton : Button
{
    public override void _Pressed()
    {
        GetNode<AudioStreamPlayer>("Click").Play();
        GD.Print("click");
    }
}
