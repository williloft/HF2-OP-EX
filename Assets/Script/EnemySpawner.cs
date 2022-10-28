using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Slime;
    [SerializeField]
    private GameObject TurtleShell;

    [SerializeField]
    private float slimeSpawnTime = 2f;
    [SerializeField]
    private float TutleShellSpawnTime = 2f;

    
    void Start()
    {
        StartCoroutine(spawnEnemy(slimeSpawnTime, Slime));
        StartCoroutine(spawnEnemy(TutleShellSpawnTime, TurtleShell));
    }

    private IEnumerator spawnEnemy(float interval, GameObject monster)
    {
        yield return new WaitForSeconds(interval);
        //Instantiate laver et nyt som er "monster" og vecter3'en bestemmer hvor den spawner
        GameObject newMonster = Instantiate(monster, new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f)), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, monster));
    }
}