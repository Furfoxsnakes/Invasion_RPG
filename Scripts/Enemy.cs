using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class Enemy : Battler
{
    public Navigation2D Nav;
    private List<Vector2> _path;
    public Player Player;
    public Area2D AggroRange;
    public Battler Target;

    public override void _Ready()
    {
        base._Ready();
        Nav = GetNode<Navigation2D>("../../Nav");
        Player = GetNode<Player>("../Player");
        AggroRange = GetNode<Area2D>("AggroRange");
        StateMachine.ChangeState<EnemyIdleState>();
    }

    public override void _PhysicsProcess(float delta)
    {
        
    }
}
