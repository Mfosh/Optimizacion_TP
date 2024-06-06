using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{

    [SerializeField] public IUpdateable[] updateables;
    [SerializeField] int a;
    // Start is called before the first frame update
    void Start()
    {
        updateables = GetComponentsInChildren<IUpdateable>(true);

    }

    // Update is called once per frame
    void Update()
    {
        var count = updateables.Length;
        for (int i = 0; i < count; i++)
        {
            updateables[i].UpdateMe();
        }
    }
}
