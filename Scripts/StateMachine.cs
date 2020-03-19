using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class StateMachine<T> : Node
{
    [Signal]
    public delegate void StateChanged(State currentState);

    [Export] private NodePath _startState;

    protected T Controller;

    protected Godot.Collections.Dictionary<string, State> StatesMap;
    protected List<State> StatesStack;
    protected State CurrentState;

    protected bool IsActive
    {
        get => _isActive;
        set
        {
            _isActive = value;
            SetPhysicsProcess(value);
            SetProcessInput(value);
            
            if (!_isActive)
            {
                StatesStack = new List<State>();
                CurrentState = null;
            }
        }
    }

    private bool _isActive;

    #region Godot

    public override void _Input(InputEvent @event)
    {
        CurrentState.HandleInput(@event);
    }

    public override void _PhysicsProcess(float delta)
    {
        CurrentState.Update(delta);
    }

    public override void _Ready()
    {
        foreach (Node child in GetChildren())
        {
            child.Connect("Finished", this, "ChangeState");
        }
        
        Initialize(GetNode<State>(_startState));
        
        AddState<PlayerState>();
        GetState<PlayerState>();
    }

    #endregion

    #region Public

    public void ChangeState(string stateName)
    {
        if (!_isActive) return;

        CurrentState?.Exit();

        if (stateName.ToLower() == "previous")
            StatesStack.RemoveAt(0);
        else
            StatesStack.Insert(0, StatesMap[stateName]);

        CurrentState = StatesStack.First();

        CurrentState?.Enter();
        
        this.PostNotification($"StateChanged", CurrentState);
    }

    #endregion
    
    private void Initialize(State startState)
    {
        IsActive = true;
        StatesStack = new List<State> {startState};
        CurrentState = startState;
        CurrentState.Enter();
        this.PostNotification($"StateChanged", CurrentState);
    }

    private void AddState<T>() where T : State
    {
        var node = new Node();
        var stateName = typeof(T).Name;
        node.Name = stateName;
        AddChild(node);
        node.SetScript(ResourceLoader.Load($"res://Scripts/{stateName}.cs"));
    }

    private void GetState<T>() where T : State
    {
        var state = FindNode("PlayerState", owned: false) as T;
        //GD.Print(state is null);
        state.Enter();
    }
}
