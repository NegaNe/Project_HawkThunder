using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling objectPooling;

    private List<GameObject> objectPoolList = new List<GameObject>();
    [SerializeField] GameObject[] EnemyObjects;

    [SerializeField] Transform pooledObjectParent;

    private void Awake()
    {
        if(objectPooling == null)
        {
            objectPooling = this;
        }
    }

    public GameObject GetObject()
    {
        for(int i = 0; i < objectPoolList.Count; i++)
        {
            if(!objectPoolList[i].activeInHierarchy)
            {
                return objectPoolList[i];
            }
        }
        return null;
    }

    public GameObject GetNewObject()
    {
        GameObject obj = Instantiate(EnemyObjects[Random.Range(0, EnemyObjects.Length)], pooledObjectParent);
        obj.SetActive(false);
        objectPoolList.Add(obj);
        return obj;
    }
}
