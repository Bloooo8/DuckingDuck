using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunInfo : MonoBehaviour {

   public int CoinAmount { get; private set;}

    ObjectPooler coinPool;
    public GameObject coinPrefab;

    void Start()
    {
        CoinAmount = 0;
        coinPool = new ObjectPooler(coinPrefab, 2);
        coinPool.Spawn(new Vector3(0, 0, 3), Quaternion.identity);
        coinPool.Spawn(new Vector3(1, 0, 4), Quaternion.identity);
    }

    public void InreaseCoinAmount()
    {
        CoinAmount++;
    }
}
