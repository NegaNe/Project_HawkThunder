using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] ObjectPooling pool;
    public Transform spawnPoint;

    public int spawnDelay;

    [ContextMenu("Start Spawn Enemy")]
    void StartSpawnEnemy()
    {
        StartCoroutine(EnemySpawnCoroutine());
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
            }
            else
            {
                GameObject newobj = pool.GetNewObject();
                newobj.SetActive(true);
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }

}
