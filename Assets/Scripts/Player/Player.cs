using System;
using StatePattern;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public PlayerSettings settings;

        [Header("Dependencies")]
        public new Rigidbody2D rigidbody;
        public PlayerInput input;
        public PlayerHook hook;

        public RaycastHit2D Grounded => Physics2D.Raycast(transform.position, Vector2.down, settings.groundDistance,
            settings.groundLayerMask);

        #region State machine

        public StateMachine StateMachine { get; private set; }
        public IdleState IdleState { get; private set; }
        public RunState RunState { get; private set; }
        public JumpState JumpState { get; private set; }
        public FallState FallState { get; private set; }
        public PlayerState CurrentState => StateMachine.CurrentState as PlayerState;

        #endregion

        #region Unity API

        private void Awake()
        {
            if (!rigidbody) rigidbody = GetComponent<Rigidbody2D>();
            if (!input) input = GetComponentInChildren<PlayerInput>();

            IdleState = new IdleState(this);
            RunState = new RunState(this);
            JumpState = new JumpState(this);
            FallState = new FallState(this);

            StateMachine = new StateMachine(IdleState);
        }

        private void Update() => StateMachine.CurrentState.Update();

        private void FixedUpdate() => StateMachine.CurrentState.FixedUpdate();

        #endregion
    }
}
