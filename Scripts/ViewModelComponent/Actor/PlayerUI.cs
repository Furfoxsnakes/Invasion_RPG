using Godot;
using System;
using InvasionRPG.Scripts.Enums;

public class PlayerUI : UI
{
    private Label _healthLabel;
    private TextureProgress _healthBar;
    private ProgressBar _xpBar;
    private Label _experienceLabel;
    private LevelUpLabel _levelUpLabel;

    public override void _Ready()
    {
        _healthLabel = GetNode<Label>("HPPanel/HBoxContainer/HPLabel");
        _healthBar = GetNode<TextureProgress>("HPPanel/HBoxContainer/HealthBar");
        _xpBar = GetNode<ProgressBar>("XPBar");
        _experienceLabel = _xpBar.GetNode<Label>("ExperienceLabel");
        _levelUpLabel = GetNode<LevelUpLabel>("LevelUpLabel");
    }

    public override void _EnterTree()
    {
        base._EnterTree();
        this.AddObserver(OnExpDidChange, Stats.DidChangeNotification(StatTypes.EXP));
        this.AddObserver(OnLvlDidChange, Stats.DidChangeNotification(StatTypes.LVL));
    }

    private void OnLvlDidChange(object sender, object args)
    {
        var stats = sender as Stats;

        if (stats.Owner != Owner) return;
        
        _levelUpLabel.Show();
    }

    private void OnExpDidChange(object sender, object args)
    {
        var stats = sender as Stats;

        if (stats.Owner != Owner) return;

        var lvlPercent = (float) (stats[StatTypes.EXP] - Rank.ExperienceForLevel(stats[StatTypes.LVL])) /
                         Rank.ExperienceForLevel(stats[StatTypes.LVL] + 1);
        _xpBar.Value = lvlPercent;
        _experienceLabel.Text = $"{stats[StatTypes.EXP]} / {Rank.ExperienceForLevel(stats[StatTypes.LVL] + 1)}";
    }

    protected override void OnHealthChange(object sender, object args)
    {
        var stats = sender as Stats;

        if (stats.Owner != Owner) return;
        
        _healthLabel.Text = stats[StatTypes.HP].ToString();
        _healthBar.Value = (float)stats[StatTypes.HP] / stats[StatTypes.MHP];
    }
}
