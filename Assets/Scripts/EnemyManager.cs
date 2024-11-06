using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] Enemies;
    [SerializeField]

    void Start()
    {
        InvokeRepeating(nameof(EnemySpawner), 0, 1f);
    }

    private void EnemySpawner()
    {
    float[] numbers = { -2.5f, 2f, 2.5f };

    GameObject SpawnedEnemies = Instantiate(Enemies[Random.Range(0, Enemies.Length)], new Vector3(numbers[Random.Range(0, numbers.Length)], 0f, 0f), Quaternion.identity);
    
    }

}
