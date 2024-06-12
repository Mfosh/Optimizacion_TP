using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMultiBall : IUpdateable
{
    [SerializeField] float _fallSpeed;
    [SerializeField] float _rotationSpeed;

    // Update is called once per frame
    public override void UpdateMe()
    {
        transform.position += new Vector3(0,-1,0) * _fallSpeed * Time.deltaTime;
        transform.Rotate(Vector3.right, _rotationSpeed * Time.deltaTime, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("MultiBAll");
            GameManager.instance.MultiBall();
            Destroy(gameObject);
        }
    }


}
