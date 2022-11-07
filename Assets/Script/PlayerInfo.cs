using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int health = 0;

    private void Start()
    {
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

        Debug.Log(stats);
        
        health = stats.health;
    }
}
