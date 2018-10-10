using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelPlanner : MonoBehaviour
{
    public static LevelPlanner Instance { get; private set; }
    int rowZPosition = 0;
    Row actualRow;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        actualRow = GenerateRow();
    }

    private void Start()
    {
        actualRow = GenerateRow();
    }

    Row GenerateRow()
    {
        rowZPosition++;
        Row row = new Row(rowZPosition);
        return row;
    }
    public  Vector3 GenerateNextCoinPosition()
    {
        if (actualRow.coinPositions.Count!=0)
        {
            Vector3 position = actualRow.coinPositions.Pop();
            return position;
        }
        else
        {
            actualRow = GenerateRow();
           return GenerateNextCoinPosition();
        }
    }

    public Vector3 GenerateNextObstaclePosition ()
    { 
        if (actualRow.obstaclePositions.Count != 0)
        {
            Vector3 position = actualRow.obstaclePositions.Pop();
            return position;
        }
        else
        {
            actualRow = GenerateRow();
            return GenerateNextObstaclePosition();
        }
    }
}

public struct Row
{
    public Stack<Vector3> coinPositions;
    public Stack<Vector3> obstaclePositions;

    public Row(int actualRowNumber){
        coinPositions = new Stack<Vector3>();
        coinPositions.Push(new Vector3(Random.Range(-1, 2), Random.Range(0, 2), actualRowNumber));
        coinPositions.Push(new Vector3(Random.Range(-1, 2), Random.Range(0, 2), actualRowNumber));
        coinPositions.Push(new Vector3(Random.Range(-1, 2), Random.Range(0, 2), actualRowNumber));
        obstaclePositions = new Stack<Vector3>();
        obstaclePositions.Push(new Vector3(Random.Range(-1, 2), Random.Range(0, 2) + 0.125f, actualRowNumber));
        obstaclePositions.Push(new Vector3(Random.Range(-1, 2), Random.Range(0, 2) + 0.125f, actualRowNumber));


    }
}
