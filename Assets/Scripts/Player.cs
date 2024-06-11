using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :IUpdateable
{
    [SerializeField] float _movementSpeed;
    [SerializeField] int _maxLife;
    int _currentLife;
    public static event Action OnStartMatch;
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

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OnStartMatch?.Invoke();
        }
        
    }


    void LoseLife()
    {
        _currentLife--;
    }


}
