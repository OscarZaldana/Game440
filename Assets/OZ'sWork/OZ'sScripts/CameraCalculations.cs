using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCalculations : MonoBehaviour
{
    public Camera cam;

    private StateMachine _stateMachine = new StateMachine();

    State isState;

    public Transform target;

    float distance2DOfZ = -10f;
    float distance2DOfY = 3f;
    float distance2DOfX = 3f;
    float distance3DOfZ = -2f;
    float distance3DOfY = 1f;
    float distance3DOfX = 1f;
    string state = "State3D";

    public void Awake()
    {
        cam = GetComponent<Camera>();
        
    }

    public void Start()
    {
        
    }

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{

        //}

        if (Input.GetKeyDown(KeyCode.S))
        {
            GameManager.Instance.StateMachine.ChangeState(GameManager.Instance.State2D);
            string current = GameManager.Instance.StateMachine.CurrentState();

            if(current == "State2D")
            {
                Debug.Log("game!!");
            }
        }
    }


    public void isIn2D()
    {
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        transform.position = new Vector3(target.position.x + distance2DOfX, target.position.y + distance2DOfY, target.position.z + distance2DOfZ);
        cam.orthographic = true;
    }

    public void isIn3D()
    {
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        transform.position = new Vector3(target.position.x + distance3DOfX, target.position.y + distance3DOfY, target.position.z + distance3DOfZ);
        cam.orthographic = false;
    }



}
