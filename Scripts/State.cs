using Godot;
using System;

public class State : Node
{
    [Signal]
    public delegate void Finished();

    protected Node Parent => GetParent().GetParent();

    public virtual void Enter()
    {
        ConnectSignals();
    }

    public virtual void Exit()
    {
        DisconnectSignals();
    }

    public virtual void HandleInput(InputEvent inputEvent)
    {
        
    }

    public virtual void Update(float delta)
    {
        
    }

    public override void _ExitTree()
    {
        // Disconnect from any signals when a scene is changed
        //DisconnectSignals();
    }

    protected virtual void ConnectSignals()
    {
        
    }

    protected virtual void DisconnectSignals()
    {
        
    }
}
