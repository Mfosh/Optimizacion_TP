using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float _fallSpeed;
    [SerializeField] float _rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,-1,0) * _fallSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime, Space.Self);
    }
}
