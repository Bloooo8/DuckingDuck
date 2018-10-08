using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    RunInfo runInfo;

    public void Start()
    {
        runInfo = FindObjectOfType<RunInfo>();
    }
    public void Collect()
    {
        runInfo.InreaseCoinAmount();
        Debug.Log("Zebrano monetę, ilość monet: " + runInfo.CoinAmount);
        GetComponent<PoolMember>().Despawn();
        GetComponent<PoolMember>().myPool.Spawn(transform.position + 2*Vector3.forward, Quaternion.identity);


    }
}
