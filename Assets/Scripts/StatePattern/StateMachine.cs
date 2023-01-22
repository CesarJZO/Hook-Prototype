namespace StatePattern
{
    public class StateMachine
    {
        public State CurrentState { get; private set; }

        public StateMachine(State initialState)
        {
            CurrentState = initialState;
        }

        public void ChangeState(State state)
        {
            CurrentState.OnEndState();
            CurrentState = state;
            CurrentState.OnStartState();
        }
    }
}
