using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TitleSelect : MonoBehaviour
{
    [SerializeField]
    Canvas _titleCanvas;
    [SerializeField]
    Button _button;




    private void OnEnable()
    {
        EventHandler.Instance.Subscribe<OnTitleEnable>(EnableTitleCanvas);
        EventHandler.Instance.Subscribe<OnTitleDisable>(DisableTitleCanvas);
    }

    private void OnDisable()
    {
        EventHandler.Instance.Unsubscribe<OnTitleEnable>(EnableTitleCanvas);
        EventHandler.Instance.Unsubscribe<OnTitleDisable>(DisableTitleCanvas);
    }

    private void Awake() 
    {
        _titleCanvas.GetComponent<Canvas>();
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene("main");
        GameManager.Instance.StateMachine.ChangeState("State2D");
    }

    public void OptionButtonClick()
    {
        GameManager.Instance.StateMachine.ChangeState("OptionState");
    }

    public void ExitGameButton()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void EnableTitleCanvas(OnTitleEnable title)
    {
        _titleCanvas.enabled = true;
    }

    public void DisableTitleCanvas(OnTitleDisable title)
    {
        _titleCanvas.enabled = false;
    }

}
