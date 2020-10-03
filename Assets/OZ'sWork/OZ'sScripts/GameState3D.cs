using System;
using UnityEngine;

public class GameState3D : State
{
    #region Variables
    private const string STATENAME = "State3D";
    #endregion

    #region Constructors
    public GameState3D() : base(STATENAME) { }
    public GameState3D(string name) : base(name) { }
    public GameState3D(StateMachine stateMachine) : base(STATENAME, stateMachine) { }
    public GameState3D(string name, StateMachine stateMachine) : base(name, stateMachine) { }
    #endregion

    #region Methods
    public override void Enter()
    {
        //on enter should notify the event call so that all objects subscribed change to 3D properties
    }
    public override void Exit()
    {

    }
    public override void FixedUpdate() { }
    public override void Update() { }
    #endregion
}
