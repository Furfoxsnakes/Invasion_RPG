using Godot;
using System;
using InvasionRPG.Scripts.Enums;
using Newtonsoft.Json;

public class GameController : Node
{
    public StateMachine StateMachine;
    [Export] private NodePath _battlersPath;
    public static Player Player;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        StateMachine = GetNode<StateMachine>("StateMachine");
        StateMachine.ChangeState<GameBeginState>(StateTypes.Game);
    }

    public void Start()
    {
        var playerScene = GD.Load<PackedScene>("res://Nodes/Player.tscn");
        Player = playerScene.Instance() as Player;
        GetNode(_battlersPath).AddChild(Player);
        Player.Position = new Vector2(100, 100);
    }

    public void Save()
    {
        var saveGame = new File();
        var path = $"user://{Player.Name}.json";
        
        var err = saveGame.Open(path, File.ModeFlags.Write);

        if (err != Error.Ok)
        {
            GD.Print($"Unable to open file at path: {path}. {err}");
            return;
        }

        foreach (Node node in GetTree().GetNodesInGroup("Persist"))
        {
            if (node is Player player)
            {
                var dataModel = player.Save();
                var json = JsonConvert.SerializeObject(dataModel);
                saveGame.StoreLine(json);
                saveGame.Close();
            }
        }
    }

    public void Load()
    {
        if (Player != null)
            Player.QueueFree();
        
        Start();
        
        string jsonString = null;
        var saveGame = new File();
        var path = $"user://{Player.Name}.json";

        var err = saveGame.Open(path, File.ModeFlags.Read);

        if (err != Error.Ok)
        {
            GD.Print($"Unable to open file at path: {path}. {err}");
            return;
        }
        
        jsonString = saveGame.GetLine();
        var playerData = JsonConvert.DeserializeObject<DataModel>(jsonString);

        for (var i = 0; i < (int) StatTypes.Count; ++i)
        {
            Player.Stats.SetValue((StatTypes)i, playerData.Stats[i], false);
        }
        
        saveGame.Close();
    }

    private void _on_NewGameButton_pressed()
    {
        Start();
        StateMachine.ChangeState<GameActiveState>(StateTypes.Game);
    }

    private void _on_LoadButton_pressed()
    {
        
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
