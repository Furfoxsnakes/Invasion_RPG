using Godot;
using System;
using InvasionRPG.Scripts.Enums;

public class PlayerDataModel
{
    public string Filename { get; set; }
    public string Parent { get; set; }
    public string Name { get; set; }
    public int[] Stats { get; set; } = new int[(int)StatTypes.Count];
}
