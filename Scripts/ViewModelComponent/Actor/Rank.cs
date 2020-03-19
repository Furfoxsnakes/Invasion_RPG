using Godot;
using System;
using InvasionRPG.Scripts.Enums;
using InvasionRPG.Scripts.Exceptions;
using InvasionRPG.Scripts.Exceptions.Modifiers;

public class Rank : Node
{
    public const int MinLevel = 1;
    public const int MaxLevel = 255;
    public const int MaxExperience = 999999;

    public int EXP
    {
        get => _stats[StatTypes.EXP];
        set => _stats[StatTypes.EXP] = value;
    }

    public int LVL => _stats[StatTypes.LVL];

    public float LevelPercent => (float) (LVL - MinLevel) / (MaxLevel - MinLevel);

    private Stats _stats;

    public override void _Ready()
    {
        _stats = GetNode<Stats>("Stats");

    }

    public override void _EnterTree()
    {
        this.AddObserver(OnExpWillChange, Stats.WillChangeNotification(StatTypes.EXP));
        this.AddObserver(OnExpDidChange, Stats.DidChangeNotification(StatTypes.EXP));
    }

    public override void _ExitTree()
    {
        this.RemoveObserver(OnExpWillChange, Stats.WillChangeNotification(StatTypes.EXP));
        this.RemoveObserver(OnExpDidChange, Stats.DidChangeNotification(StatTypes.EXP));
    }

    private void OnExpDidChange(object sender, object args)
    {
        _stats.SetValue(StatTypes.LVL, LevelForExperience(EXP), false);
    }

    private void OnExpWillChange(object sender, object args)
    {
        var vce = args as ValueChangeException;
        vce?.AddModifier(new ClampValueModifier(int.MaxValue, EXP, MaxExperience));
    }
    
    public static int LevelForExperience(int exp)
    {
        var lvl = MaxLevel;
        
        for (; lvl >= MinLevel; --lvl)
            if (exp >= ExperienceForLevel(lvl))
                break;

        return lvl;
    }

    private static int ExperienceForLevel(int lvl)
    {
        // TODO: figure how to clamp to a value between 0 - 1
        return 0;
    }
}
