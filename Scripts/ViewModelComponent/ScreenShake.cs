using Godot;
using System;

public class ScreenShake : Node
{
    public const string CameraShakeNotification = "Camera.Shake";
    private Camera2D _camera;

    [Export] private float _decay = 0.8f;
    [Export] private Vector2 _max_offset = new Vector2(100,75);
    [Export] private float _max_roll = 0.1f;
    [Export] private float _maxTrauma = 0.35f;

    private float _trauma = 0.0f;
    private float _trauma_power = 3;

    public override void _Ready()
    {
        _camera = GetParent<Camera2D>();
        this.AddObserver(OnCameraShake, CameraShakeNotification);
    }

    public override void _Process(float delta)
    {
        if (_trauma >= 0)
        {
            _trauma = Mathf.Max(_trauma - _decay * delta, 0);
            Shake();
        }
    }

    private void OnCameraShake(object sender, object e)
    {
        AddTrauma((float)e);
    }

    private void AddTrauma(float amount)
    {
        // clamps the trauma to be between 0 - 1
        _trauma = Mathf.Min(_trauma + amount, _maxTrauma);
    }

    private void Shake()
    {
        var amount = Mathf.Pow(_trauma, _trauma_power);
        _camera.Rotation = _max_roll * amount * (float)GD.RandRange(-1, 1);
        var x_offset = _max_offset.x * amount * (float)GD.RandRange(-1, 1);
        var y_offset = _max_offset.y * amount * (float)GD.RandRange(-1, 1);
        _camera.Offset = new Vector2(x_offset, y_offset);
    }
}
