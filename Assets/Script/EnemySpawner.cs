using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public EnemyScriptableObjects[] enemyScriptableObjects;
    
    private float spawnTimer = 8f;
    private float spawnTime = 8f;

    private void Update()
    {
        // timer
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            // spawn enemy
            SpawnEnemy();
            // reset timer
            spawnTimer = spawnTime;
        }
    }

    // spawner method
    public void SpawnEnemy()
    {
        // get random enemy
        int randomEnemy = Random.Range(0, enemyScriptableObjects.Length);
        // get random position
        Vector3 randomPosition = new Vector3(Random.Range(-8f, 8f), 0, Random.Range(-8f, 8f));
        // spawn enemy
        Instantiate(enemyScriptableObjects[randomEnemy].prefab, randomPosition, Quaternion.identity);
    }
}
