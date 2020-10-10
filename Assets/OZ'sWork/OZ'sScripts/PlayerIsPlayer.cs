using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsPlayer : MonoBehaviour
{
    public Transform pos;



    public void Awake()
    {
        pos = GetComponent<Transform>(); 
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
