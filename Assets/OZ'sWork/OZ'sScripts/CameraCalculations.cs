using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCalculations : MonoBehaviour
{
    public Camera cam;

    private StateMachine _stateMachine = new StateMachine();

    public Transform target;


    public void Awake()
    {
        cam = GetComponent<Camera>();

    }

    public void Start()
    {

    }

    private void OnEnable()
    {
        EventHandler.Instance.Subscribe<OnChangeDimension>(OnCameraChange);
    }

    private void OnDisable()
    {
        EventHandler.Instance.Unsubscribe<OnChangeDimension>(OnCameraChange);       
    }

    public void Update()
    {

    }

    public void OnCameraChange(OnChangeDimension dimension)
    {
        if (dimension.Dimension == "State2D")
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z - 3);
            cam.orthographic = true;
        }
        else if (dimension.Dimension == "State3D")
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
            cam.orthographic = false;
        }
        else Debug.Log("At this point mechanics should be the same but display is active");

    }

}






//if (Input.GetKeyDown(KeyCode.Space))
//{
//    GameManager.Instance.StateMachine.ChangeState(GameManager.Instance.State3D);
//    string current = GameManager.Instance.StateMachine.CurrentState();

//    if (current == "State3D")
//    {
//        Debug.Log("game3D!!");
//    }
//}