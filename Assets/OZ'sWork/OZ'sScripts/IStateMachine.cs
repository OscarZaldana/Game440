/*IStateMachine is an interface for the states so that they can be called
 easier*/

public interface IStateMachine
{
    void ChangeState(State toState);
    void ChangeState(string toState);
    void AddState(State state);
    void RemState(State state);
    void UpdateActiveState();
    void FixedUpdateActiveState();
    string CurrentState();
}
