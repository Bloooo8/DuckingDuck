using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolMember : MonoBehaviour
{
    [SerializeField]
    public ObjectPooler myPool;

    public void SetMyPool(ObjectPooler pool)
    {
        this.myPool = pool;
    }

    public void Despawn()
    {
        gameObject.SetActive(false);
        myPool.pooledObjects.Push(gameObject);
    }
}
