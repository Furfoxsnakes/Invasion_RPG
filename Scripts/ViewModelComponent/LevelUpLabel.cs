using Godot;
using System;

public class LevelUpLabel : Label
{
    private Timer _displayTime;
    private Tween _tweener;

    public override void _EnterTree()
    {
        _displayTime = GetNode<Timer>("DisplayTime");
        _displayTime.Connect("timeout", this, nameof(OnDisplayTimeTimeout));
        _tweener = GetNode<Tween>("Tweener");
    }

    private void OnDisplayTimeTimeout()
    {
        Hide();
    }

    public void Show()
    {
        Visible = true;
        _displayTime.Start();
    }

    public void Hide()
    {
        Visible = false;
    }
}
