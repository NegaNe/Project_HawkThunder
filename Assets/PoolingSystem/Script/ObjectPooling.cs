using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling objectPooling;

    private List<GameObject> objectPoolList = new List<GameObject>();
    [SerializeField] GameObject objectToPool;

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
        GameObject obj = Instantiate(objectToPool, pooledObjectParent);
        obj.SetActive(false);
        objectPoolList.Add(obj);
        return obj;
    }
}
