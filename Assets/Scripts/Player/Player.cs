using StatePattern;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        #region State machine

        public StateMachine StateMachine { get; private set; }
        public IdleState IdleState { get; private set; }
        public RunState RunState { get; private set; }
        public JumpState JumpState { get; private set; }
        public PlayerState CurrentState => StateMachine.CurrentState as PlayerState;

        #endregion

        #region Unity API

        private void Awake()
        {
            IdleState = new IdleState(this);
            RunState = new RunState(this);
            JumpState = new JumpState(this);

            StateMachine = new StateMachine(IdleState);
        }

        #endregion
    }
}
