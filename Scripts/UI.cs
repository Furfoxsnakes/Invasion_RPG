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
    
    public override void _ExitTree()
    {
        this.RemoveObserver(OnHealthChange, Stats.DidChangeNotification(StatTypes.HP));
        this.RemoveObserver(OnMaxHealthChange, Stats.DidChangeNotification(StatTypes.MHP));
    }
    
    protected virtual void OnMaxHealthChange(object sender, object args)
    {
        OnHealthChange(sender, args);
    }

    protected virtual void OnHealthChange(object sender, object args)
    {
        
    }
}
