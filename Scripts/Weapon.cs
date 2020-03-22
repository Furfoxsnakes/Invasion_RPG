using Godot;
using System;
using InvasionRPG.Scripts.Enums;

public class Weapon : Node2D
{
    [Export] public PackedScene Projectile;
    [Export] public float BulletSpeed = 400f;
    [Export] private float _screenShakeTrauma = 0.25f;
    [Export] private float _shotsPerSeconds = 2;

    public StateMachine StateMachine;
    
    //TODO: Implement crosshair feedback for spread before it can be used
    /*
    [Export] private float _minSpreadAmount = 5f;
    [Export] private float _maxSpreadAmount = 20f;
    [Export] private float _spreadAmount;
    [Export] private float _spreadDecay = 5f;
    */

    public Timer FireRate;

    private Position2D _spawnPoint;
    
    public override void _Ready()
    {
        StateMachine = GetNode<StateMachine>("StateMachine");
        StateMachine.ChangeState<WeaponIdleState>(StateTypes.Weapon);
        FireRate = GetNode<Timer>("FireRate");
        _spawnPoint = GetNode<Position2D>("ProjectileSpawnPoint");
        FireRate.WaitTime = (60 / _shotsPerSeconds) / 60;
        //_spreadAmount = _minSpreadAmount;
    }

    public override void _PhysicsProcess(float delta)
    {
        //_spreadAmount = Mathf.Max(_spreadAmount - _spreadDecay * delta, _minSpreadAmount);
    }

    public void Shoot()
    {
        var projectile = Projectile.Instance() as Projectile;
        projectile.Source = Owner as Battler;
        GetTree().Root.AddChild(projectile);
        if (projectile != null)
        {
            projectile.Position = _spawnPoint.GlobalPosition;
            projectile.RotationDegrees = GlobalRotationDegrees;
            projectile.ApplyImpulse(Vector2.Zero,
                new Vector2(BulletSpeed, 0).Rotated(
                    GlobalRotation /*+ Mathf.Deg2Rad((float)GD.RandRange(-_spreadAmount,_spreadAmount))*/));
        }

        //this.PostNotification(ScreenShake.CameraShakeNotification, _screenShakeTrauma);
        //_spreadAmount = Mathf.Min(_spreadAmount + 2f, _maxSpreadAmount);
    }
}
