using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerInfo stats;
    [SerializeField] private TextMeshProUGUI healthText;

    static UIManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        healthText.text = $"Health {stats.health}";
    }
    
    public static void UpdateHealth()
    {
        instance.HealthChange();
    }

    public void HealthChange()
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