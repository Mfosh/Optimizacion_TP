using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{

    [SerializeField] public List <IUpdateable> updateables = new List<IUpdateable>();
    [SerializeField] int a;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
