using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum PoolType {Bullet};

[System.Serializable]
public class ObjectPool
{
    public PoolType poolType;
    public GameObject prefabObject;
    public Queue<GameObject> objectQueue;

}

public class ObjectPooler : MonoBehaviour
{
    public ObjectPool[] objectPools;

    // Start is called before the first frame update
    void Start()
    {
        foreach(ObjectPool objectPool in objectPools)
        {
            objectPool.objectQueue = new Queue<GameObject>();
        }
    }

    public void AddToPool(PoolType poolType, GameObject item)
    {
        item.SetActive(false);
        FindByPoolType(poolType).objectQueue.Enqueue(item);
    }

    public GameObject GetFromPool(PoolType poolType)
    {
        ObjectPool objectPool = FindByPoolType(poolType);
        if(objectPool.objectQueue.Count > 0)
        {
            return objectPool.objectQueue.Dequeue();
        }
        else
        {
            return Instantiate(objectPool.prefabObject);
        }
    }

    private ObjectPool FindByPoolType(PoolType poolType)
    {
        ObjectPool result = null;
        foreach(ObjectPool objectPool in objectPools)
        {
            if(objectPool.poolType == poolType)
                result = objectPool;
        }

        return result;
    }
}
