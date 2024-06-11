using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    BallPool ballPool;
    [SerializeField]List<GameObject> ActiveBalls;
    [SerializeField] List<GameObject> ActiveBlocks;
    public static GameManager instance;
    UpdateManager updateManager;
    int PlayerScore;
    public GameObject panelWin;
    public GameObject panelLose;

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

    
    public void AddToUpdateList(IUpdateable updateable)
    {
        updateManager.updateables.Add(updateable);
    }


    public void LostBall(GameObject Ball)
    {
        ballPool.ReturnToPool(Ball);
        ActiveBalls.Remove(Ball);

        if (ActiveBalls.Count <= 0)
        {
            panelLose.SetActive(true);
        }
    }

    public void BlockDestroyed(Block block, int Points)
    {
        Debug.Log(Points);
        ActiveBlocks.Remove(block.gameObject);
        PlayerScore += Points;
        Debug.Log(PlayerScore);

        if (ActiveBlocks.Count <= 0)
        {
            panelWin.SetActive(true);
        }
    }
}
