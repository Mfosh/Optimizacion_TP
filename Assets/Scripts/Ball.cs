using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : IUpdateable   
{
    [SerializeField] float _movementSpeed;
    float angle;
    [SerializeField] float RotationSpeed;
    Vector3 dir;
    float BallRadius;
    public bool moving;
    Transform PlayerPos;
    // Start is called before the first frame update
    void Start()
    {
        
        BallRadius = GetComponent<SphereCollider>().radius * Mathf.Max(transform.lossyScale.x, transform.lossyScale.y, transform.lossyScale.z);
        Debug.Log(BallRadius);
        if (!moving)
        {
            dir = new Vector2(0, 0);
        }
        Player.OnStartMatch += StartMovement;
    }




    void Rotate()
    {
        angle += Input.GetAxis(("Mouse X")) * RotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
  
        //Check with player
        if (collision.gameObject.tag == "Player")
        {
            dir.y = -dir.y;
        }

       // if (collision.gameObject.GetComponent<Ball>())
       // {
       //     dir.x = -dir.x;
       // }

        //BlocksHit
        if (collision.gameObject.GetComponent<Block>())
        {

            BlockCollision(collision.gameObject);
            collision.gameObject.GetComponent<Block>().OnHit();
         
        }

        //SideWalls
        if (collision.gameObject.layer == 6)
            dir.x = -dir.x;
        //TopWall
        if (collision.gameObject.layer == 7)
            dir.y = -dir.y;
    }

    void BlockCollision(GameObject Block)
    {
        //Get the Actual Size of the Block
        var blockCollider = Block.GetComponent<Renderer>();

        


        
        //Calculate the exact positions of each side of the block
        float BlockLeft = Block.transform.position.x - blockCollider.bounds.size.x /2;
        float BlockRight = Block.transform.position.x + blockCollider.bounds.size.x / 2;
        
        float BlockTop = Block.transform.position.y + blockCollider.bounds.size.y / 2;
        float BlockBot = Block.transform.position.y - blockCollider.bounds.size.y / 2;

        
        if (transform.position.y + BallRadius <= Block.transform.position.y && transform.position.x > BlockLeft && transform.position.x < BlockRight)
        {
            dir.y = -1;
       
        }
       
        if (transform.position.y - BallRadius >= Block.transform.position.y && transform.position.x > BlockLeft && transform.position.x < BlockRight)
        {
            dir.y = 1;
    
        }


        if (transform.position.x >=  BlockRight && transform.position.y + BallRadius > BlockBot && transform.position.y - BallRadius < BlockTop)
        {

            dir.x = 1;
        }

       else if (transform.position.x <= BlockLeft  && transform.position.y + BallRadius > BlockBot && transform.position.y - BallRadius < BlockTop)
        {

            dir.x = -1;
        }


    }

    public override void UpdateMe()
    {

        Move(dir);

        if (transform.position.y <= -5)
        {
            GameManager.instance.LostBall(this.gameObject);
        }
    }


    void Move(Vector3 direction)
    {
        transform.position += direction * _movementSpeed * Time.deltaTime;
    }

    public void StartMovement()
    {
        dir = new Vector2(Random.RandomRange(-1,1), 1);
        if (dir.x == 0)
        {
            dir.x = 0.5f;
        }
        Debug.Log("StartMoving");
    }

}
