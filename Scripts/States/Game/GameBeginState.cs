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
        LoadGameButton.Visible = false;
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
            StateMachine.ChangeState<GameActiveState>(StateTypes.Game);
        }
    }

    private void UpdateCountdown()
    {
        GameStateLabel.Text = $"Get ready {PlayerData.Name}. Starting in...{_count}";
    }
}
