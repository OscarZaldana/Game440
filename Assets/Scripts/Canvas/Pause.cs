using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    Canvas _pauseCanvas;

    string lastState;

    bool pauseState = false;

    private void OnEnable()
    {
        EventHandler.Instance.Subscribe<OnPauseEvent>(EnablePauseCanvas);
        EventHandler.Instance.Subscribe<UnPauseEvent>(DisablePauseCanvas);
    }

    private void OnDisable()
    {
        EventHandler.Instance.Unsubscribe<OnPauseEvent>(EnablePauseCanvas);
        EventHandler.Instance.Unsubscribe<UnPauseEvent>(DisablePauseCanvas);
    }

    private void Awake()
    {
        _pauseCanvas.GetComponent<Canvas>();
        _pauseCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseState = !pauseState;
        }


        if ((GameManager.Instance.StateMachine.CurrentState() == "State3D" || GameManager.Instance.StateMachine.CurrentState() == "State2D") && pauseState == true)
        {
            lastState = GameManager.Instance.StateMachine.CurrentState();
            GameManager.Instance.StateMachine.ChangeState("PauseState");
        }

        if (GameManager.Instance.StateMachine.CurrentState() == "PauseState" && pauseState == false)
        {
            GameManager.Instance.StateMachine.ChangeState(lastState);
        }
    }

    public void EnablePauseCanvas(OnPauseEvent pause)
    {
        _pauseCanvas.enabled = true;
    }

    public void DisablePauseCanvas(UnPauseEvent pause)
    {
        _pauseCanvas.enabled = false;
    }
}