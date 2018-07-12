using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunInfo : MonoBehaviour {

   public int CoinAmount { get; private set;}

    void Start()
    {
        CoinAmount = 0;
    }

    public void InreaseCoinAmount()
    {
        CoinAmount++;
    }
}
