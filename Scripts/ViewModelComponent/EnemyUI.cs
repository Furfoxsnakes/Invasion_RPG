using Godot;
using System;
using InvasionRPG.Scripts.Enums;

public class EnemyUI : UI
{
    private TextureProgress _healthBar;

    public override void _Ready()
    {
        _healthBar = GetNode<TextureProgress>("HealthBar");
    }

    protected override void OnHealthChange(object sender, object args)
    {
        var stats = sender as Stats;

        if (stats.Owner != Owner) return;

        _healthBar.Value = MathHelpers.Clamp01(stats[StatTypes.HP], stats[StatTypes.MHP]);
    }
}
