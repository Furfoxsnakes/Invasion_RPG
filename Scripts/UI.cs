using System.Runtime.CompilerServices;
using Godot;
using InvasionRPG.Scripts.Enums;

public class UI : CanvasLayer
{
    public override void _EnterTree()
    {
        this.AddObserver(OnHealthChange, Stats.DidChangeNotification(StatTypes.HP));
    }

    private void OnHealthChange(object sender, object args)
    {
        var stats = sender as Stats;
        
        // Only process changes to stats that are made to this node's owner
        if (stats.Owner != Owner) return;

        GetNode<Label>("HPPanel/HBoxContainer/HPLabel").Text = stats[StatTypes.HP].ToString();
    }

    public override void _Ready()
    {
        
    }
}
