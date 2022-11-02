using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        other.gameObject.transform.Find("Armors").Find("Plate1").gameObject.SetActive(true);
        other.gameObject.transform.Find("Armors").Find("StarterClothes").gameObject.SetActive(false);
    }
}
