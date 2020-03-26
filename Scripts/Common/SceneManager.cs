using Godot;
using System;

public static class SceneManager
{
    public static Error ChangeToScene(this Node node, string path)
    {
        return node.GetTree().ChangeScene(path);
    }
}
