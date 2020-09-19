using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D sc = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
        Debug.Log(sc.bounds.size.x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

