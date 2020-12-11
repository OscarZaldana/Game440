/*This script is suppossed to call the state changes that happen in game
 when the state changes it should invoke an event notice so that the proper stuff can be called for it
ex: in Title state it will notify the canvas that brings up the proper images for the screen*/

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    //[SerializeField] private GameObject player3D = null;
    //[SerializeField] private GameObject player2D = null;

    #region State Variables
    [SerializeField] private StateMachine _stateMachine = new StateMachine();
    private State _titleState;
    private State _optionsState;
    private State _pauseState;
    private State _State3D;
    private State _State2D;
    private string sceneName;
    #endregion

    #region Properties
    public StateMachine StateMachine { get { return _stateMachine; } set { _stateMachine = value; } }
    public State TitleState { get { return _titleState; } set { _titleState = value; } }
    public State OptionsState { get { return _optionsState; } set { _optionsState = value; } }
    public State PauseState { get { return _pauseState; } set { _pauseState = value; } }
    public State State3D { get { return _State3D; } set { _State3D = value; } }
    public State State2D { get { return _State2D; } set { _State2D = value; } }

    //public GameObject Player3D
    //{
    //    get
    //    {
    //        if (player3D == null)
    //        {
    //            player3D = Player3DPrefab;
    //        }
    //        return player3D;
    //    }
    //    set { player3D = value; }
    //}
    //public GameObject Player2D
    //{
    //    get
    //    {
    //        if (player2D == null)
    //        {
    //            player2D = Player2DPrefab;
    //        }
    //        return player2D;
    //    }
    //    set { player2D = value; }
    //}
    //public GameObject Player3DPrefab
    //{
    //    get
    //    {
    //        if (player3dPrefab == null)
    //        {
    //            player3DPrefab = Resources.Load<GameObject>("getGrefab");
    //            Debug.Log("No prefab selected for Player3D. Adding default one");
    //        }
    //        return Player3DPrefab;
    //    }
    //    set { player3dPrefab = value; }
    //}

    //public GameObject Player2DPrefab
    //{
    //    get
    //    {
    //        if (player2DPrefab == null)
    //        {
    //            player2DPrefab = Resources.Load<GameObject>("getPrefab");
    //            Debug.Log("No prefab selected for Player2D. Adding default one");
    //        }
    //        return player2DPrefab;
    //    }
    //    set { player2DPrefab = value; }
    //}
    #endregion

    #region MonoBehaviour
    public void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    public void OnEnable()
    {
        LoadGameStates();
    }

    public void Update()
    {
        _stateMachine.UpdateActiveState();
        _stateMachine.CurrentState();
    }

    #endregion

    #region Class Methods
    private void LoadGameStates()
    {

        TitleState = new TitleState(_stateMachine);
        OptionsState = new OptionState(_stateMachine);
        PauseState = new PauseState(_stateMachine);
        State3D = new GameState3D(_stateMachine);
        State2D = new GameState2D(_stateMachine);

        if (sceneName == "GameScene1") _stateMachine.ChangeState(State2D);
        else _stateMachine.ChangeState(TitleState);

    }
    #endregion
}