using Godot;
using System;
using InvasionRPG.Scripts.Enums;

public class EnemyUI : UI
{
    private ProgressBar _healthBar;

    public override void _Ready()
    {
        GetNode<ProgressBar>("HealthBar");
    }

    protected override void OnHealthChange(object sender, object args)
    {
        base.OnHealthChange(sender, args);
        _healthBar.MaxValue = Stats[StatTypes.MHP];
        _healthBar.MinValue = Stats[StatTypes.HP];
        _healthBar.Value = Mathf.FloorToInt(Stats[StatTypes.HP] / Stats[StatTypes.MHP]);
    }
}
