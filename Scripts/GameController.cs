using Godot;
using System;
using InvasionRPG.Scripts.Enums;
using Newtonsoft.Json;

public class GameController : Node
{
    public StateMachine StateMachine;
    [Export] private NodePath _battlersPath;
    public Player Player;
    public GameData GameData => GetTree().Root.GetNode<GameData>("GameData");

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        StateMachine = GetNode<StateMachine>("StateMachine");
        StateMachine.ChangeState<GameBeginState>(StateTypes.Game);
    }

    public void Start()
    {
        if (Player != null)
            Player.QueueFree();

        var playerScene = GD.Load<PackedScene>("res://Nodes/Player.tscn");
        Player = playerScene.Instance() as Player;
        GetNode(_battlersPath).AddChild(Player);
        Player.Position = new Vector2(100, 100);
    }

    public void Save()
    {
        var err = FileManager.SavePlayerData(Player);

        if (err != Error.Ok)
        {
            GD.PrintErr($"Unable to save game: {err}");
        }
        else
            GD.Print($"Save game successful: {err}");
    }

    public void Load()
    {
        var playerData = GameData.PlayerData;
        
        if (GameData.PlayerData == null)
            return;
        
        GD.Print(playerData);

        for (var i = 0; i < (int) StatTypes.Count; ++i)
        {
            Player.Stats.SetValue((StatTypes)i, playerData.Stats[i], false);
        }
    }

    private void _on_NewGameButton_pressed()
    {
        this.ChangeToScene("res://Nodes/MainMenu.tscn");
    }

    private void _on_LoadButton_pressed()
    {
        Start();
        Load();
        StateMachine.ChangeState<GameActiveState>(StateTypes.Game);
    }
    
    private void _on_SaveButton_pressed()
    {
        Save();
    }

    private void _on_RestartButton_pressed()
    {
        GetTree().ReloadCurrentScene();
    }

    private void _on_QuitButton_pressed()
    {
        GetTree().Quit();
    }
}
