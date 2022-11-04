using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("item Information")]
    public Sprite itemIcon;
    public string itemName;
    public GameObject modelPrefab;
}
