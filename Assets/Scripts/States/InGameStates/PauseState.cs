using System;
using UnityEngine;

public class PauseState : State
{
    #region Variables
    private const string STATENAME = "PauseState";
    #endregion

    #region Constructors
    public PauseState() : base(STATENAME) { }
    public PauseState(string name) : base(name) { }
    public PauseState(StateMachine stateMachine) : base(STATENAME, stateMachine) { }
    public PauseState(string name, StateMachine stateMachine) : base(name, stateMachine) { }
    #endregion

    #region Methods
    public override void Enter()
    {
        EventHandler.Instance.Broadcast(new OnPauseEvent());
    }
    public override void Exit()
    {
        EventHandler.Instance.Broadcast(new UnPauseEvent());
    }
    public override void FixedUpdate() { }
    public override void Update() { }
    #endregion
}
