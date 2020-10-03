/**/

using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class StateMachine : IStateMachine
{
    [SerializeField] private string _stateName = string.Empty;
    [SerializeField] private string _stateInfo = string.Empty;
    private State _activeState;
    private State _lastState;
    private List<State> _states = new List<State>();

    #region Properties
    public State ActiveState { get { return _activeState; } set { _activeState = value; } }
    public State LastState { get { return _lastState; } set { _lastState = value; } }
    public List<State> States { get { return _states; } set { _states = value; } }
    public string StateInfo { get { return _stateInfo; } set { _stateInfo = value; } }
    #endregion

    #region Constructors
    public StateMachine() { }
    public StateMachine(params State[] stateList)
    {
        foreach (State state in stateList)
        {
            AddState(state);
        }
    }
    #endregion

    #region Class Methods
    // Change State via State Reference
    public void ChangeState(State toState)
    {
        if (ActiveState != null)
            ActiveState.Exit();
        if (LastState != null && !LastState.Equals(toState))
            LastState = ActiveState;
        ActiveState = toState;
        ActiveState.Enter();
    }

    // Change State via String Reference. Checks to see if there are multiple entries & does NOT switch if so.
    public void ChangeState(string toState)
    {
        bool _found = false;
        State _foundState = null;
        foreach (State state in States)
        {
            if (state.Name == toState)
            {
                if (_found)
                {
                    Debug.Log("Unable to Change States. Multiple Entries found: [" + toState + "]");
                    return;
                }
                else
                {
                    _found = true;
                    _foundState = state;
                }
            }
        }
        if (_found)
            ChangeState(_foundState);
        else
            Debug.Log("StateMachine does not contain an entry for: " + toState);
    }

    // Add a State to the State Machine
    public void AddState(State state)
    {
        if (state.Name == null || state.Name == string.Empty)
        {
            state.Name = state.ToString();
        }
        state.StateMachine = this;
        States.Add(state);
    }

    // Removes a state from the List
    public void RemState(State state)
    {
        States.Remove(state);
    }

    public void UpdateActiveState()
    {
        if (ActiveState != null)
            ActiveState.Update();
    }

    public void FixedUpdateActiveState()
    {
        if (ActiveState != null)
            ActiveState.FixedUpdate();
    }
    #endregion
}
