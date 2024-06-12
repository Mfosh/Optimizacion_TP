using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int HitstoDestroy;
    [SerializeField] int CurrentHits;
    [SerializeField] GameObject PowerUp;
    [SerializeField] public int Points;
    AudioSource audio;
    

    void Start()
    {
        audio = GetComponent<AudioSource>();
        CurrentHits = HitstoDestroy;
    }



    public void OnHit()
    {
        audio.Play();
        CurrentHits--;
        if(CurrentHits <= 0)
        {
            if (PowerUp)
            {
                GameObject powerUP = Instantiate(PowerUp,this.transform.position, PowerUp.transform.rotation);
                GameManager.instance.AddToUpdateList(powerUP.GetComponent<PowerUpMultiBall>());
            }
            DestroyBlock();
            Destroy(this.gameObject);
        }
    }

    void DestroyBlock()
    {
        GameManager.instance.BlockDestroyed(this, Points);

    }

}
