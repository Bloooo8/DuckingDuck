using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler
{
    public Stack<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    int nextId = 1;

    public ObjectPooler(GameObject prefab, int quantity)
    {
        this.objectToPool = prefab;
        this.amountToPool = quantity;
        InstantiateObjects();
    }


    void InstantiateObjects()
    {
        pooledObjects = new Stack<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = GameObject.Instantiate(objectToPool);
            obj.name = objectToPool.name + " (" + (nextId++) + ")";
            obj.AddComponent<PoolMember>().SetMyPool(this);
            obj.SetActive(false);
            pooledObjects.Push(obj);
        }
    }
    public GameObject Spawn(Vector3 position,Quaternion rotation)
    {
        GameObject obj;
        if (pooledObjects.Count == 0)
        {
            obj = (GameObject)GameObject.Instantiate(objectToPool,position,rotation);
            obj.name = objectToPool.name + " (" + (nextId++) + ")";
            obj.AddComponent<PoolMember>().SetMyPool(this);
        }
        else
        {
            obj = pooledObjects.Pop();

            if (obj == null)
            {
                return Spawn(position,rotation);
            }
        }
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);
        return obj;
    }
    public void Despawn(GameObject obj)
    {
        obj.SetActive(false);
        pooledObjects.Push(obj);
    }
}
