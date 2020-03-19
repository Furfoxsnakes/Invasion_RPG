using Godot;
using System;
using System.Collections.Generic;
using InvasionRPG.Scripts.Enums;
using InvasionRPG.Scripts.Exceptions;

public class Stats : Node
{
    public int this[StatTypes s]
    {
        get => _data[(int) s];
        set => SetValue(s, value, true);
    }

    private int[] _data = new int[(int) StatTypes.Count];
    private static Dictionary<StatTypes, string> _willChangeNotifications = new Dictionary<StatTypes, string>();
    private static Dictionary<StatTypes, string> _didChangeNotifications = new Dictionary<StatTypes, string>();

    public static string WillChangeNotification(StatTypes type)
    {
        if (!_willChangeNotifications.ContainsKey(type))
            _willChangeNotifications.Add(type, $"Stats.{type.ToString()}WillChange");

        return _willChangeNotifications[type];
    }

    public static string DidChangeNotification(StatTypes type)
    {
        if (!_didChangeNotifications.ContainsKey(type))
            _didChangeNotifications.Add(type, $"Stats.{type.ToString()}DidChange");

        return _didChangeNotifications[type];
    }
    
    public void SetValue(StatTypes type, int value, bool allowException)
    {
        var oldValue = this[type];
        if (value == oldValue) return;

        if (allowException)
        {
            var exc = new ValueChangeException(oldValue, value);

            this.PostNotification(WillChangeNotification(type), exc);

            value = Mathf.FloorToInt(exc.GetModifiedValue());

            if (exc.Toggle || value == oldValue) return;
        }

        _data[(int) type] = value;

        this.PostNotification(DidChangeNotification(type), oldValue);
    }
}
