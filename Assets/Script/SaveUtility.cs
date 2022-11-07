using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using UnityEngine;

public class SaveUtility : MonoBehaviour
{
    string path = "Assets/PlayerStats.dat";

    public Stats player;

    BinaryFormatter converter = new BinaryFormatter();


    private void Start()
    {
        LoadStats();

        Thread SS = new Thread(UpdateStats);

        SS.Start();
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Saving player stats");

        SaveStats();
    }

    void UpdateStats()
    {
        Thread.Sleep(1000 * 10);
        Debug.Log("Updated stats");
        SaveStats();
    }

    void LoadStats()
    {
        if (File.Exists(path))
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            player = converter.Deserialize(fileStream) as Stats;

            fileStream.Close();
        }
        else Debug.LogError("No save file found");
    }

    void SaveStats()
    {
        var fileStream = new FileStream(path, FileMode.Create);

        converter.Serialize(fileStream, player);

        fileStream.Close();
    }
}