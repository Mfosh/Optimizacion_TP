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
                GameObject powerUP = Instantiate(PowerUp,this.transform.position, PowerUp.transform.rotation);
                GameManager.instance.AddPowerUpTOUpdateList(powerUP.GetComponent<PowerUpMultiBall>());
            }
            Destroy(this.gameObject);
        }
    }

}
