using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    WeaponSlotManger weaponSlotManger;

    public WeaponItem leftWeapon;
    public WeaponItem rightWeapon;


    private void Awake()
    {
        weaponSlotManger = GetComponentInChildren<WeaponSlotManger>();
    }

    private void Start()
    {
        weaponSlotManger.LoadWeaponOnSlot(leftWeapon, false);
        weaponSlotManger.LoadWeaponOnSlot(rightWeapon, true);
    }
}
