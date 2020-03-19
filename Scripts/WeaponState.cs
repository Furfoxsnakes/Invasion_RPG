using Godot;
using System;

public class WeaponState : State
{
    protected Weapon Weapon => Parent as Weapon;
    protected NewStateMachine StateMachine => Weapon.StateMachine;
    
    protected Timer FireRate => Weapon.FireRate;

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void HandleInput(InputEvent inputEvent)
    {
        if (inputEvent is InputEventMouseMotion motion)
        {
            Weapon.LookAt(Weapon.GetGlobalMousePosition());
        }
    }

    public override void Update(float delta)
    {
        
    }
}
