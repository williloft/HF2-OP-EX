using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using UnityEngine;

[Serializable]
public static class SaveUtility
{
    private static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    
    static BinaryFormatter converter = new BinaryFormatter();

    private static PlayerInfo player;

    private static Thread SS;
    
    // Kaldes i starten af spillet før alle andre metoder i dette script
    public static void Start()
    {
        path += "\\My Games\\MyGame\\SaveData.dat";

        SS = new Thread(UpdateStats);

        SS.Start();
    }
    

    public static void OnApplicationQuit()
    {
        Debug.Log("Saving player stats");

        SaveStats(player);
    }
    
    // Auto save player stats hver gang der er gået 10 minutter

    static void UpdateStats()
    {
        while (true)
        {
            Thread.Sleep(1000 * 60 * 10);
            Debug.Log("Updated stats");
            SaveStats(player);
        }
    }

    // Kaldes fra et andet script eller metode når spilleren skal gemmes
    public static void SaveStats(PlayerInfo player)
    {
        using (FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
        {
            EnsureFolder(path);
            File.SetAttributes(path, FileAttributes.Normal);
            PlayerStats data = new PlayerStats(player);

            converter.Serialize(file, data);
            file.Close();
        }
    }

    // Kaldes fra et andet script når man vil load stats
    public static PlayerStats LoadStats()
    {
        if (File.Exists(path))
        {
            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                EnsureFolder(path);
                BinaryFormatter bf = new BinaryFormatter();
                File.SetAttributes(path, FileAttributes.Normal);

                PlayerStats stats = (PlayerStats)bf.Deserialize(file);

                return stats;
            }
        }
        Debug.LogError("Save file blev ikke fundet i " + path);
        return null;
    }
    // sikre at mappen eksisterer ellers så laver den en

    static void EnsureFolder(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }
    }
}