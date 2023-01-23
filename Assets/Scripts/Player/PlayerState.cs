using StatePattern;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public abstract class PlayerState : State
    {
        private readonly Player _player;

        protected PlayerState(Player player) => _player = player;

        public virtual bool ReadInput(InputAction.CallbackContext context, InputCommand command) => false;

        #region Dependencies wrapper

        protected RaycastHit2D Grounded => _player.Grounded;
        protected PlayerSettings Settings => _player.settings;
        protected Rigidbody2D Rigidbody => _player.rigidbody;
        protected PlayerInput Input => _player.input;

        #endregion

        #region State machine

        protected bool ChangeState(PlayerState state)
        {
            if (!state) return false;
            _player.StateMachine.ChangeState(state);
            return true;
        }

        #endregion

        #region States wrapper

        protected IdleState Idle => _player.IdleState;
        protected RunState Run => _player.RunState;
        protected JumpState Jump => _player.JumpState;
        protected FallState Fall => _player.FallState;

        #endregion
    }
}
