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

    static void UpdateStats()
    {
        while (true)
        {
            Thread.Sleep(1000 * 10);
            Debug.Log("Updated stats");
            SaveStats(player);
            if(SS.IsAlive == false)
            {
                break;
            }
        }
        Debug.Log("Thread ended");
    }

    public static void SaveStats(PlayerInfo player)
    {
        using (FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
        {
            EnsureFolder(path);
            File.SetAttributes(path, FileAttributes.Normal);
            PlayerStats data = new PlayerStats(player);
            
            Debug.Log("Is thread alive? " + SS.IsAlive);

            converter.Serialize(file, data);
            file.Close();
        }
    }

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
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    static void EnsureFolder(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }
    }
}