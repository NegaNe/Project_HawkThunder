using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] ObjectPooling pool;
    public Transform spawnPoint;

    public int spawnDelay;

    private Coroutine healthIncreaserCoroutine;


    [Header("Health System")]
    public int defaultHealth = 10;

    public int givenEnemyHealth;

    public int enemyHealthDelayIncrease = 5;


    private void Start()
    {
        StartSpawnEnemy();
        givenEnemyHealth = defaultHealth;
    }

    [ContextMenu("Start Spawn Enemy")]
    void StartSpawnEnemy()
    {
        StartCoroutine(EnemySpawnCoroutine());

        healthIncreaserCoroutine = StartCoroutine(HealthIncreaser());
    }

    private IEnumerator EnemySpawnCoroutine()
    {
        while (true)
        {
            GameObject obj = pool.GetObject();

            if (obj != null)
            {
                obj.transform.position = spawnPoint.transform.position;
                obj.SetActive(true);
                EnemyHealth enemyHealth = obj.GetComponent<EnemyHealth>();

                if(enemyHealth != null)
                {
                    enemyHealth.enemyHealth = givenEnemyHealth;
                }
            }
            else
            {
                GameObject newobj = pool.GetNewObject();
                newobj.SetActive(true);
                EnemyHealth enemyHealth = newobj.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                {
                    enemyHealth.enemyHealth = givenEnemyHealth;
                }
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private IEnumerator HealthIncreaser()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemyHealthDelayIncrease);
            givenEnemyHealth += 5;
        }
    }


}
