using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :IUpdateable
{
    [SerializeField] float _movementSpeed;
    [SerializeField] int _maxLife;
    int _currentLife;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.AddToUpdateList(this.GetComponent<Player>());
        _currentLife = _maxLife;
    }

    // Update is called once per frame
   public override void UpdateMe()
    {
        Vector3 horizontal = new Vector3( Input.GetAxis("Horizontal"),0,0);

        transform.position += horizontal * _movementSpeed * Time.deltaTime;
        
    }


    void LoseLife()
    {
        _currentLife--;
    }


}
