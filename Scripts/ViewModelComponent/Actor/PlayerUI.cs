using Godot;
using System;
using InvasionRPG.Scripts.Enums;

public class PlayerUI : UI
{
    protected override void OnHealthChange(object sender, object args)
    {
        base.OnHealthChange(sender, args);
        GetNode<Label>("HPPanel/HBoxContainer/HPLabel").Text = Stats[StatTypes.HP].ToString();
    }
}
