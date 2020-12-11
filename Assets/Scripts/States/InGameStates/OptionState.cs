using System;
using UnityEngine;

public class OptionState : State
{
    #region Variables
    private const string STATENAME = "OptionState";
    #endregion

    #region Constructors
    public OptionState() : base(STATENAME) { }
    public OptionState(string name) : base(name) { }
    public OptionState(StateMachine stateMachine) : base(STATENAME, stateMachine) { }
    public OptionState(string name, StateMachine stateMachine) : base(name, stateMachine) { }
    #endregion

    #region Methods
    public override void Enter()
    {
        EventHandler.Instance.Broadcast(new OnOptionEnable());
    }
    public override void Exit()
    {
        EventHandler.Instance.Broadcast(new OnOptionDisable());
    }
    public override void FixedUpdate() { }
    public override void Update() { }
    #endregion
}
