using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounderies : MonoBehaviour
{
    Camera mainCamera;
    public CameraType cameraType;

    // Use this for initialization
    void Start()
    {
        // mainCamera = Camera.main;
        Debug.Log(cameraType);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
