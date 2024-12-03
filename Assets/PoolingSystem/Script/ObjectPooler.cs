using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] ObjectPooling pool;
    public Transform spawnPoint;
    public float delay;

    /*private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PoolObject();
        }
    }*/
    [ContextMenu("Start Shoot")]
    void StartShoot()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            PoolObject();
            
            yield return new WaitForSeconds(delay);
        }
    }

    public void PoolObject()
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
    }
}
