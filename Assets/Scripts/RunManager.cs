using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunManager:MonoBehaviour  {

    public static RunManager Instance { get; private set; }

    public int CoinAmount { get; private set;}

    ObjectPooler coinPool;
    public GameObject coinPrefab;

    ObjectPooler obstaclesPool;
    [SerializeField]
    GameObject obstaclePrefab;

    LevelPlanner levelPlanner;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        levelPlanner = LevelPlanner.Instance;
        CoinAmount = 0;
        InitializeCoins();
        InitializeObstacles();    
    }
    void InitializeCoins()
    {
        coinPool = new ObjectPooler(coinPrefab, 10);
        for(int i=0;i<10;i++)
        {
            coinPool.Spawn(levelPlanner.GenerateNextCoinPosition(), Quaternion.identity);
        }
    }
    void InitializeObstacles()
    {
        obstaclesPool = new ObjectPooler(obstaclePrefab, 10);
        for (int i = 0; i < 10; i++)
        {
            obstaclesPool.Spawn(levelPlanner.GenerateNextObstaclePosition(), Quaternion.identity);
        }
    }
    public void InreaseCoinAmount()
    {
        CoinAmount++;
    }

    public void ZeroCoins()
    {
        CoinAmount = 0;
    }
}
