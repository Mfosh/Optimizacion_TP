using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    BallPool ballPool;
    List<GameObject> ActiveBalls;
    [SerializeField] List<GameObject> ActiveBlocks;


void Start()
    {
        ballPool = GetComponent<BallPool>();
        ActiveBalls = new List<GameObject>();

        ActiveBalls.Add(ballPool.GetBall());
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MultiBall();
        }
        
    }

    void MultiBall()
    {
        int currentBalls = ActiveBalls.Count;
        for (int i = 0; i < currentBalls; i++)
        {
            for (int b = 0; b < 2; b++)
            {
                GameObject Ball = ballPool.GetBall();
                Ball.transform.position = ActiveBalls[i].transform.position;
                ActiveBalls.Add(Ball);
            }
              
        
        }
    }
}
