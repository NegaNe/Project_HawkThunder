using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] Enemies;
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private float SpawnInterval;

    void Start()
    {
        StartCoroutine(nameof(EnemySpawner));
    }

    private IEnumerator EnemySpawner()
    {
        while(true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(SpawnInterval);
        }
    }

    private void SpawnEnemy()
    {
    GameObject enemy = ObjectPooling.objectPooling.GetObject();
    
    if(enemy != null)
        {
        Transform EnemySpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        enemy.transform.position = EnemySpawnPoint.position;
        }


    }

}
