using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Inventory/Enemy")]
public class EnemyScriptableObjects : ScriptableObject
{
    public int maxhealth;
    public int attackDamage;
    public int walkSpeed;
    public GameObject prefab;
}
