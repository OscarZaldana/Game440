using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualIntercom : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeDimension();
        }
    }


    //Interaction button test
    public void ChangeDimension()
    {
        string current = GameManager.Instance.StateMachine.CurrentState();

        if (current == "State3D")
        {
            GameManager.Instance.StateMachine.ChangeState("State2D");
        }
        else if (current == "State2D")
        {
            GameManager.Instance.StateMachine.ChangeState("State3D");
        }
        else
        {
            Debug.Log("some other state change");
        }
    }
}
