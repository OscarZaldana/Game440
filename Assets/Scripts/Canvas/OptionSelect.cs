using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionSelect : MonoBehaviour
{
    [SerializeField]
    Canvas _optionCanvas;

    private void OnEnable()
    {
        EventHandler.Instance.Subscribe<OnOptionEnable>(EnableOptionCanvas);
        EventHandler.Instance.Subscribe<OnOptionDisable>(DisableOptionCanvas);
    }

    private void OnDisable()
    {
        EventHandler.Instance.Unsubscribe<OnOptionEnable>(EnableOptionCanvas);
        EventHandler.Instance.Unsubscribe<OnOptionDisable>(DisableOptionCanvas);
    }

    private void Awake()
    {
        _optionCanvas.GetComponent<Canvas>();
        _optionCanvas.enabled = false;
    }

    public void BackButtonClick()
    {
        GameManager.Instance.StateMachine.ChangeState("TitleState");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnableOptionCanvas(OnOptionEnable option)
    {
        _optionCanvas.enabled = true;
    }

    public void DisableOptionCanvas(OnOptionDisable option)
    {
        _optionCanvas.enabled = false;
    }
}
