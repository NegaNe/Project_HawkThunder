using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public Transform spawnPoint;


    private void Update()
    {
        
    }

    public void PoolObject()
    {
        GameObject obj = ObjectPooling.objectPooling.GetObject();

        if (obj != null)
        {
            obj.transform.position = spawnPoint.transform.position;
            obj.SetActive(true);
        }
        else
        {
            GameObject newobj = ObjectPooling.objectPooling.GetNewObject();
            newobj.SetActive(true);
        }
    }
}
