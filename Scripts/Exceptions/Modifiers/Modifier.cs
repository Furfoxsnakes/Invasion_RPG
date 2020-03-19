using Godot;
using System;

public abstract class Modifier
{
    public readonly int SortOrder;

    public Modifier(int sortOrder)
    {
        SortOrder = sortOrder;
    }
}
