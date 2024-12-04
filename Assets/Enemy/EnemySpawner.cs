using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner enemySpawner;

    [SerializeField] ObjectPooling pool;
    public Transform spawnPoint;

    public int spawnDelay;

    private Coroutine healthIncreaserCoroutine;


    [Header("Health System")]
    public int defaultHealth = 10;
    
    public static int givenEnemyHealth = 10;

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
                /*if(obj.gameObject.name == "EnemyPlane")
                {
                    obj.GetComponent<EnemyHealth>().enemyHealth = givenEnemyHealth;
                }*/
                

            }
            else
            {
                GameObject newobj = pool.GetNewObject();
                newobj.SetActive(true);
                /*if (newobj.gameObject.name == "EnemyPlane")
                {
                    newobj.GetComponent<EnemyHealth>().enemyHealth = givenEnemyHealth;
                }*/
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
