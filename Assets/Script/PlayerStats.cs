using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading;

[Serializable]
public class PlayerStats : MonoBehaviour
{
    public int health = 100;

    public PlayerStats(PlayerInfo player)
    {
        health = player.health;
    }
}
