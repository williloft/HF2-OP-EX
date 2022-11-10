using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface EnemyStats
{
    
    int Health { get; set; }
    int Damage { get; set; }
    int Speed { get; set; }
    int AttackSpeed { get; set; }
    int AttackRange { get; set; }
    int VisionRange { get; set; }
}

public class slime : EnemyStats
{
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Speed { get; set; }
    public int AttackSpeed { get; set; }
    public int AttackRange { get; set; }
    public int VisionRange { get; set; }

    public slime()
    {
        Health = 100;
        Damage = 10;
        Speed = 5;
        AttackSpeed = 1;
        AttackRange = 1;
        VisionRange = 5;
    }
}
    

