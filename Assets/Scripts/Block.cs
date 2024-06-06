using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int HitstoDestroy;
    [SerializeField] int CurrentHits;
    [SerializeField] GameObject PowerUp;

    void Start()
    {
        CurrentHits = HitstoDestroy;
    }



    public void OnHit()
    {
        CurrentHits--;
        if(CurrentHits <= 0)
        {
            if (PowerUp)
            {
                Instantiate(PowerUp,this.transform.position, PowerUp.transform.rotation);
            }
            Destroy(this.gameObject);
        }
    }

}
