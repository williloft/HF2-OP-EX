using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManger : MonoBehaviour
{
    WeaponHolderSlot leftHandSlot;
    WeaponHolderSlot rightHandSlot;

    private void Awake()
    {
        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();

        foreach (WeaponHolderSlot weaponHolderSlot in weaponHolderSlots) 
        // denne foreach søger vores player model igennem og kigger efter WeaponHolderSlot og finder ud af om det er left or right.
        {
            if (weaponHolderSlot.isLeftHandSlot)
            {
                leftHandSlot = weaponHolderSlot;
            }
            else if (weaponHolderSlot.isRightHandSlot)
            {
                rightHandSlot = weaponHolderSlot;
            }
        }
    }

    public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isRight )
    {
        if (isRight)
        {
            rightHandSlot.LoadWeaponModel(weaponItem);
        }
        else
        {
            leftHandSlot.LoadWeaponModel(weaponItem);
        }
    }
}
