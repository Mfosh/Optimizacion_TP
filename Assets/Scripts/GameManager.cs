using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    BallPool ballPool;
    [SerializeField]List<GameObject> ActiveBalls;
    [SerializeField] List<GameObject> ActiveBlocks;
    public static GameManager instance;
    UpdateManager updateManager;
    int PlayerScore;
    Player player;
    public GameObject panelWin;
    public GameObject panelLose;
    public TMP_Text score;

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
        AddToUpdateList(player);
        Player.OnStartMatch += LaunchBalls;

    }


    public void MultiBall()
    {
        int currentBalls = ActiveBalls.Count;
        Debug.Log(currentBalls);
        for (int i = 0; i < currentBalls; i++)
        {
            for (int b = 0; b < 2; b++)
            {
                GameObject Ball = ballPool.GetBall();
                Ball.transform.position = ActiveBalls[i].transform.position;
                ActiveBalls.Add(Ball);
                Ball ball = Ball.GetComponent<Ball>();
                updateManager.updateables.Add(ball);
                ball.moving = true;
                ball.StartMovement();
            }
              
        
        }
    }

    
    public void AddToUpdateList(IUpdateable updateable)
    {
        updateManager.updateables.Add(updateable);
    }

    void LaunchBalls()
    {
        int size = ActiveBalls.Count;
        for (int i = 0; i < size; i++)
        {

        }
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

        score.text = PlayerScore.ToString();

        if (ActiveBlocks.Count <= 0)
        {
            panelWin.SetActive(true);
        }
    }
}
