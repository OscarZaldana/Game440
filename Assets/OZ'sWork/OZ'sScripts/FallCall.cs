using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCall : MonoBehaviour
{

    private void OnEnable()
    {
        EventHandler.Instance.Subscribe<KareemEvent>(KEvent);
    }

    private void OnDisable()
    {
        EventHandler.Instance.Unsubscribe<KareemEvent>(KEvent);
        EventHandler.Instance.Unsubscribe<KareemEvent>(KEvent);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.StateMachine.ChangeState("State3D");
        }
    }

    public void KEvent(KareemEvent ke)
    {
        Debug.Log("hello");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "metal post")
        {
            EventHandler.Instance.Broadcast(new OnhitMetal());
            AudioManager.Instance.PlaySound("Help", 1f);
        }
    }



}
