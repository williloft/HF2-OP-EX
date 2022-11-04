using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/item")]
public class WeaponItem : Item
{
    public GameObject modelPrefab;
    public bool isUnarmed;
}
