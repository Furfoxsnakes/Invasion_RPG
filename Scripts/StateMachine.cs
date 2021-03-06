using Godot;
using System;
using InvasionRPG.Scripts.Enums;

public class StateMachine : Node
{
    public State CurrentState
    {
        get => _currentState;
        set => Transition(value);
    }
    private State _currentState;

    private bool _inTransition;

    #region Godot

    public override void _Input(InputEvent @event)
    {
        CurrentState.HandleInput(@event);
    }

    public override void _PhysicsProcess(float delta)
    {
        CurrentState.Update(delta);
    }

    #endregion

    public void ChangeState<T>(StateTypes type) where T : State
    {
        CurrentState = GetState<T>(type);
    }

    private State GetState<T>(StateTypes type) where T : State
    {
        if (FindNode(typeof(T).Name, owned: false) is T state) return state;
        
        var node = new Node();
        var stateName = typeof(T).Name;
        node.Name = stateName;
        AddChild(node);
        node.SetScript(ResourceLoader.Load($"res://Scripts/States/{type}/{stateName}.cs"));
        state = GetNode<T>(stateName);

        return state;
    }

    private void Transition(State newState)
    {
        if (_currentState == newState || _inTransition) return;

        _inTransition = true;
        
        if (_currentState != null)
            _currentState.Exit();

        _currentState = newState;
        
        if (_currentState != null)
            _currentState.Enter();

        _inTransition = false;

    }
}
