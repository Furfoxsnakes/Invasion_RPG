using Godot;
using System;

public class MainMenuController : Node
{
    private LineEdit _inputBox => GetNode<LineEdit>("VBoxContainer/InputBox");
    private Button _startGameButton => GetNode<Button>("VBoxContainer/StartGameButton");
    private GameData _gameData => GetTree().Root.GetNode<GameData>("GameData");

    private void _on_StartGameButton_pressed()
    {
        StartGame(_inputBox.Text);
    }

    private void _on_InputBox_text_changed(string text)
    {
        if (string.IsNullOrEmpty(text))
            _startGameButton.Disabled = true;
        else
            _startGameButton.Disabled = false;
    }

    private void _on_InputBox_text_entered(string text)
    {
        if (!string.IsNullOrEmpty(text))
            StartGame(text);
        else
            GD.PrintErr("Name field is empty");
    }

    private void StartGame(string playerName)
    {
        _gameData.PlayerData = new PlayerDataModel()
        {
            Name = playerName
        };
        GetTree().ChangeScene("res://Nodes/Game.tscn");
    }
}
