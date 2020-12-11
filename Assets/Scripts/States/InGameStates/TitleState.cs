using System;
using UnityEngine;


public class TitleState : State
{
    #region Variables
    private const string STATENAME = "TitleState";
    #endregion

    #region Constructors
    public TitleState() : base(STATENAME) { }
    public TitleState(string name) : base(name) { }
    public TitleState(StateMachine stateMachine) : base(STATENAME, stateMachine) { }
    public TitleState(string name, StateMachine stateMachine) : base(name, stateMachine) { }
    #endregion

    #region Methods
    public override void Enter() 
    {
        EventHandler.Instance.Broadcast(new OnTitleEnable());
    }
    public override void Exit()
    {
        EventHandler.Instance.Broadcast(new OnTitleDisable());
    }
    public override void FixedUpdate() { }
    public override void Update() { }
    #endregion
}

