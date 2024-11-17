using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling objectPooling;
    private List<GameObject> objectPoolList = new List<GameObject>();
    [SerializeField] GameObject objectToPool;
    [SerializeField] int PoolSize;

    private Queue<GameObject> objectPoolQueue = new Queue<GameObject>();

    public interface IPoolable
    {
        void ResetObject();
    }


    // [SerializeField] Transform pooledObjectParent;

    private void Awake()
    {
        if(objectPooling == null)
        {
            objectPooling = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        initializePool(PoolSize);
    }

    public void initializePool(int count)
    {
    for (int i = 0; i < count; i++)
        {
        GameObject obj = Instantiate(objectToPool, transform);
        obj.SetActive(false);
        objectPoolQueue.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        if(objectPoolQueue.Count > 0)
        {
        GameObject obj = objectPoolQueue.Dequeue();
        obj.SetActive(true);
        return obj;
        }
        return null;
    }

    public void ReturnToPool(GameObject obj)
    {
    obj.SetActive(false);
    }
}
