using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerInfo : MonoBehaviour
{
    public int health = 0;

    private void Start()
    {
        SaveUtility.Start();
        LoadPlayer();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SavePlayer();
        }
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            LoadPlayer();
        }
    }

    void SavePlayer()
    {
        SaveUtility.SaveStats(this);
    }

    void LoadPlayer()
    {
        var stats = SaveUtility.LoadStats();

        health = stats.health;

        UIManager.UpdateHealth();
    }

    private void OnApplicationQuit()
    {
        SaveUtility.OnApplicationQuit();
    }
}
