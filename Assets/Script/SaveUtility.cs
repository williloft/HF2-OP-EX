using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using UnityEngine;

public static class SaveUtility
{
    private static string path = Application.persistentDataPath + "/Save.data";

    static BinaryFormatter converter = new BinaryFormatter();
    
    private static PlayerInfo player;
    
    private static void Start()
    {
        Thread SS = new Thread(UpdateStats);

        SS.Start();

        SS.Join();
    }

    private static void OnApplicationQuit()
    {
        Debug.Log("Saving player stats");

        SaveStats(player);
    }

    static void UpdateStats()
    {
        Thread.Sleep(1000 * 10);
        Debug.Log("Updated stats");
        SaveStats(player);
        UpdateStats();
    }

    public static void SaveStats(PlayerInfo player)
    {
        FileStream Stream = new FileStream(path, FileMode.Create);
        
        PlayerStats data = new PlayerStats(player);
        
        converter.Serialize(Stream, data);
        Stream.Close();
        
    }

    public static PlayerStats LoadStats()
    {
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            
            PlayerStats stats = (PlayerStats)bf.Deserialize(file);
            file.Close();

            return stats;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}