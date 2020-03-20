using System.Runtime.CompilerServices;
using Godot;
using InvasionRPG.Scripts.Enums;

public class UI : Node
{
    protected Stats Stats;
    
    public override void _EnterTree()
    {
        this.AddObserver(OnHealthChange, Stats.DidChangeNotification(StatTypes.HP));
        this.AddObserver(OnMaxHealthChange, Stats.DidChangeNotification(StatTypes.MHP));
    }

    private void OnMaxHealthChange(object sender, object args)
    {
        OnHealthChange(sender, args);
    }

    public override void _ExitTree()
    {
        this.RemoveObserver(OnHealthChange, Stats.DidChangeNotification(StatTypes.HP));
        this.RemoveObserver(OnMaxHealthChange, Stats.DidChangeNotification(StatTypes.MHP));
    }

    protected virtual void OnHealthChange(object sender, object args)
    {
        var stats = sender as Stats;
        
        // Only process changes to stats that are made to this node's owner
        if (stats.Owner != Owner) return;
        Stats = stats;
    }
}
