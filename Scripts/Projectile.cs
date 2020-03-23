using Godot;
using System;

public class Projectile : RigidBody2D
{
    public Battler Source;
    
    private void _on_Projectile_body_entered(Battler battler)
    {
        if (battler is Enemy)
        {
            battler.TakeDamage(5, Source);
        }
        
        QueueFree();
    }

    private void _on_TTL_timeout()
    {
        QueueFree();
    }

    private void _on_VisibilityNotifier2D_viewport_exited(Viewport viewport)
    {
        QueueFree();
    }
}
