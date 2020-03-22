using Godot;
using System;
using InvasionRPG.Scripts.Enums;

public class PlayerUI : UI
{
    private Label _healthLabel;

    public override void _Ready()
    {
        _healthLabel = GetNode<Label>("HPPanel/HBoxContainer/HPLabel");
    }

    protected override void OnHealthChange(object sender, object args)
    {
        var stats = sender as Stats;

        if (stats.Owner != Owner) return;
        
        _healthLabel.Text = stats[StatTypes.HP].ToString();
    }
}
