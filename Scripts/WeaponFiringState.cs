using Godot;
using System;

public class WeaponFiringState : WeaponState
{
    public override void Update(float delta)
    {
        if (!FireRate.IsStopped()) return;
        
        FireRate.Start();
        Weapon.Shoot();
    }

    public override void HandleInput(InputEvent inputEvent)
    {
        base.HandleInput(inputEvent);
        
        if (inputEvent is InputEventMouseButton button)
            if (!button.Pressed) StateMachine.ChangeState<WeaponIdleState>();
    }
}
