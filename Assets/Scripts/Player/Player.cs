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

        #endregion

        #region Unity API

        private void Awake()
        {
            IdleState = new IdleState(this);
            RunState = new RunState(this);

            StateMachine = new StateMachine(IdleState);
        }

        #endregion
    }
}
