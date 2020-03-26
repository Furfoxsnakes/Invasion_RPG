using Godot;
using System;
using Newtonsoft.Json;

public static class FileManager
{
    public static PlayerDataModel LoadPlayerData(string path)
    {
        PlayerDataModel dataToReturn = null;

        var file = new File();
        var err = file.Open(path, File.ModeFlags.Read);
        
        GD.Print(err);

        if (err != Error.Ok)
        {
            GD.PrintErr($"Unable to open file at path: {path}. {err}");
            return null;
        }

        var jsonString = file.GetLine();

        dataToReturn = JsonConvert.DeserializeObject<PlayerDataModel>(jsonString);
        
        GD.Print(dataToReturn);

        file.Close();

        return dataToReturn;
    }

    public static Error SavePlayerData(Player player)
    {
        var playerData = player.Save();
        
        var file = new File();
        var path = $"user://{playerData.Name}.save";

        var err = file.Open(path, File.ModeFlags.Write);

        if (err != Error.Ok)
            return err;

        var json = JsonConvert.SerializeObject(playerData);
        file.StoreLine(json);
        file.Close();

        return err;
    }
}
