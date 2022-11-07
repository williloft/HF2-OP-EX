using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Stats stats;
    [SerializeField] private TextMeshProUGUI healthText;

    private void Start()
    {
        healthText.text = $"Health {stats.health}";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            DamagePlayer();
        }
    }

    void DamagePlayer()
    {
        stats.health--;
        healthText.text = $"Health {stats.health}";
    }
}