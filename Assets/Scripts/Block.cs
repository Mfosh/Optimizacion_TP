using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int HitstoDestroy;
    [SerializeField] int CurrentHits;

    void Start()
    {
        CurrentHits = HitstoDestroy;
    }



    public void OnHit()
    {
        CurrentHits--;
        if(CurrentHits <= 0)
        {

            Destroy(this.gameObject);
        }
    }

}
