using Godot;
using System;

public class Projectile : RigidBody2D
{
    private void _on_Projectile_body_entered(Node body)
    {
        GD.Print(body is Enemy);
        QueueFree();
    }

    private void _on_TTL_timeout()
    {
        QueueFree();
    }
}
