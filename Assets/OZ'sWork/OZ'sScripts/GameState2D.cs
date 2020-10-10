using System;
using UnityEngine;

public class GameState2D : State
{
    #region Variables
    private const string STATENAME = "State2D";
    #endregion

    #region Constructors
    public GameState2D() : base(STATENAME) { }
    public GameState2D(string name) : base(name) { }
    public GameState2D(StateMachine stateMachine) : base(STATENAME, stateMachine) { }
    public GameState2D(string name, StateMachine stateMachine) : base(name, stateMachine) { }
    #endregion

    #region Methods
    public override void Enter()
    {
        Debug.Log("2DState");
    }
    public override void Exit()
    {

    }
    public override void FixedUpdate() { }
    public override void Update() { }
    #endregion
}