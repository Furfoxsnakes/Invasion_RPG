using Godot;
using System;
using InvasionRPG.Scripts.Enums;

public class PlayerUI : UI
{
    private Label _healthLabel;
    private TextureProgress _healthBar;

    public override void _Ready()
    {
        _healthLabel = GetNode<Label>("HPPanel/HBoxContainer/HPLabel");
        _healthBar = GetNode<TextureProgress>("HPPanel/HBoxContainer/HealthBar");
    }

    protected override void OnHealthChange(object sender, object args)
    {
        var stats = sender as Stats;

        if (stats.Owner != Owner) return;
        
        _healthLabel.Text = stats[StatTypes.HP].ToString();
        _healthBar.Value = MathHelpers.Clamp01(stats[StatTypes.HP], stats[StatTypes.MHP]);
    }
}
