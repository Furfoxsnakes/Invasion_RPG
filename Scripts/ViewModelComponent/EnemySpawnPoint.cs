using Godot;
using System;
using InvasionRPG.Scripts.Enums;

public class EnemySpawnPoint : Position2D
{
    [Export] private PackedScene _enemyToSpawn;
    [Export] private float _timeBetweenSpawns = 15;
    private Timer _spawnTimer;

    public override void _Ready()
    {
        _spawnTimer = GetNode<Timer>("SpawnTimer");
    }

    public void Start()
    {
        SpawnEnemy();
        _spawnTimer.Start(_timeBetweenSpawns);
    }
    
    private void SpawnEnemy()
    {
        var enemy = _enemyToSpawn.Instance() as Enemy;
        enemy.Position = Position;
        GetTree().Root.GetNode("Game").GetNode("Battlers").AddChild(enemy);
    }

    private void _on_SpawnTimer_timeout()
    {
        SpawnEnemy();
    }
}
