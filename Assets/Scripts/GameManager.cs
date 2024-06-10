using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    BallPool ballPool;
    List<GameObject> ActiveBalls;
    [SerializeField] List<GameObject> ActiveBlocks;
    public static GameManager instance;
    UpdateManager updateManager;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        updateManager = GetComponent<UpdateManager>();

        ballPool = GetComponent<BallPool>();
        ActiveBalls = new List<GameObject>();
  
    }
    void Start()
    {


        ActiveBalls.Add(ballPool.GetBall());
        updateManager.updateables.Add(ActiveBalls[0].GetComponent<Ball>());

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MultiBall();
        }
        
    }

    public void MultiBall()
    {
        int currentBalls = ActiveBalls.Count;
        for (int i = 0; i < currentBalls; i++)
        {
            for (int b = 0; b < 2; b++)
            {
                GameObject Ball = ballPool.GetBall();
                Ball.transform.position = ActiveBalls[i].transform.position;
                ActiveBalls.Add(Ball);
                updateManager.updateables.Add(Ball.GetComponent<Ball>());
            }
              
        
        }
    }

    
    public void AddPowerUpTOUpdateList(IUpdateable updateable)
    {
        updateManager.updateables.Add(updateable);
    }


}
