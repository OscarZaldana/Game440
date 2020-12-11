/**/

public abstract class State : IState
{
    private string _name = string.Empty;
    private StateMachine _stateMachine;

    #region Properties
    public string Name { get { return _name; } set { _name = value; } }
    public StateMachine StateMachine { get { return _stateMachine; } set { _stateMachine = value; } }
    public StateMachine SM { get { return _stateMachine; } set { _stateMachine = value; } }
    #endregion

    #region Constructors
    public State() { }
    public State(string name) { this._name = name; }
    public State(StateMachine stateMachine) : this(string.Empty, stateMachine) { }
    public State(string name, StateMachine stateMachine)
    {
        this._name = (name != string.Empty) ? name : string.Empty;
        this._stateMachine = stateMachine;
        this._stateMachine.AddState(this);
    }
    #endregion

    #region Class Methods
    public abstract void Enter();
    public abstract void Update();
    public abstract void FixedUpdate();
    public abstract void Exit();
    #endregion
}
