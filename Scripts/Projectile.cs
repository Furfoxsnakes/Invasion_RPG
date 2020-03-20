using Godot;
using System;

public class Projectile : RigidBody2D
{
    private void _on_Projectile_body_entered(Battler battler)
    {
        // Do damage to body that was hit
        QueueFree();
    }

    private void _on_TTL_timeout()
    {
        QueueFree();
    }
}
