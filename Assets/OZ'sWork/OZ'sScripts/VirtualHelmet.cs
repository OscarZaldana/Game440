using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualHelmet : MonoBehaviour
{

    public void Update()
    {

    }


    //Interaction button test
    public void ChangeDimension()
    {
        string current = GameManager.Instance.StateMachine.CurrentState();

        if (current == "State3D")
        {
            GameManager.Instance.StateMachine.ChangeState(GameManager.Instance.State2D);           
        }
        else if (current == "State2D")
        {           
            GameManager.Instance.StateMachine.ChangeState(GameManager.Instance.State3D);
        }
        else
        {
            Debug.Log("some other state change");
        }
    }
}
