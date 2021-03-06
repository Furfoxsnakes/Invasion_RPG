using Godot;
using System;
using InvasionRPG.Scripts.Enums;

public class GameBeginState : GameState
{
    private Timer _countdownTimer;
    private int _count;
    
    public override void Enter()
    {
        base.Enter();
        IsGamePaused = true;
        NewGameButton.Visible = false;
        RestartButton.Visible = false;
        SaveGameButton.Visible = false;
        QuitButton.Visible = false;
        UIContainer.Visible = true;
        BeginCountdown();
    }

    private void BeginCountdown()
    {
        _count = 5;
        UpdateCountdown();
        _countdownTimer = new Timer();
        _countdownTimer.Connect("timeout", this, nameof(OnCountdownTimerTimeout));
        AddChild(_countdownTimer);
        _countdownTimer.Start(1f);
    }

    private void OnCountdownTimerTimeout()
    {
        _count--;
        UpdateCountdown();
        if (_count == 0)
        {
            _countdownTimer.Stop();
            Game.Start();
            InitPlayerData();
            StateMachine.ChangeState<GameActiveState>(StateTypes.Game);
        }
    }

    private void UpdateCountdown()
    {
        GameStateLabel.Text = $"Get ready {GameData.PlayerData.Name}. Starting in...{_count}";
    }

    private void InitPlayerData()
    {
        var playerData = GameData.PlayerData;
        
        for (var i = 0; i < (int) StatTypes.Count; ++i)
        {
            Game.Player.Stats.SetValue((StatTypes)i, playerData.Stats[i], false);
        }
    }
}
