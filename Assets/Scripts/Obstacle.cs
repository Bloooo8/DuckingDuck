using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour,IEnemy,IItem
{
    RunManager runManager;
    PoolMember poolMember;
    Vector3 nextObstaclePosition;
    LevelPlanner levelPlanner;


    public void Start()
    {
        runManager = RunManager.Instance;
        poolMember = GetComponent<PoolMember>();
        levelPlanner = LevelPlanner.Instance;
    }
    public void OnCollision()
    {
        runManager.ZeroCoins();
        SceneManager.LoadSceneAsync(0);
    }

    public void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy == true)
        {
            poolMember.Despawn();
            nextObstaclePosition = levelPlanner.GenerateNextObstaclePosition();
            poolMember.myPool.Spawn(nextObstaclePosition, Quaternion.identity);
        }     
    }
  
}
