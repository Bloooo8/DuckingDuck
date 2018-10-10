using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable,IItem
{
    RunManager runManager;
    PoolMember poolMember;
    Vector3 nextCoinPosition;
    LevelPlanner levelPlanner;

    public void Start()
    {
        runManager = RunManager.Instance;
        poolMember = GetComponent<PoolMember>();
        levelPlanner = LevelPlanner.Instance;
    }
    public void Collect()
    {
        runManager.InreaseCoinAmount();
        Debug.Log("Zebrano monetę, ilość monet: " + runManager.CoinAmount);
        poolMember.Despawn();
        nextCoinPosition = levelPlanner.GenerateNextCoinPosition();
        poolMember.myPool.Spawn(nextCoinPosition, Quaternion.identity);
    }
  
    public void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy == true)
        {
            poolMember.Despawn();
            nextCoinPosition = levelPlanner.GenerateNextCoinPosition();
            poolMember.myPool.Spawn(nextCoinPosition, Quaternion.identity);
        }
      
    }
}
