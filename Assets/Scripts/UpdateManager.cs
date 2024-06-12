using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{

    [SerializeField] public List <IUpdateable> updateables = new List<IUpdateable>();
    [SerializeField] int a;
    public bool isplaying;
    // Start is called before the first frame update
    void Start()
    {
        isplaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isplaying)
        {
            var count = updateables.Count;
            for (int i = 0; i < count; i++)
            {
                if (updateables[i] != null && updateables[i].isActiveAndEnabled)
                {
                    updateables[i].UpdateMe();
                }
                else
                {
                    updateables.RemoveAt(i);

                    count = updateables.Count;
                }

            }
        }
    }
}
