using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using UnityEngine;

public class SaveUtility : MonoBehaviour
{
    private string path = "unknown";

    public Stats player;

    BinaryFormatter converter = new BinaryFormatter();

    private FileStream fileStream;

    private void Awake()
    {
        path = Application.persistentDataPath + "/Save.data";

        fileStream = new FileStream(path,
            FileMode.OpenOrCreate,
            FileAccess.ReadWrite,
            FileShare.None);
    }

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
        UpdateStats();
    }
    
    void SaveStats()
    {
        using(var fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            converter.Serialize(fs, player);
        }
    }
    
    void LoadStats()
    {
        using(var fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            player = (Stats)converter.Deserialize(fs);
        }
    }

}