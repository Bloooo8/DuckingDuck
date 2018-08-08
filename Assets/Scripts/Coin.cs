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
        GameObject.Destroy(gameObject);


    }
}
