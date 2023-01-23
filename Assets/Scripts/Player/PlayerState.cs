using StatePattern;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public abstract class PlayerState : State
    {
        protected readonly Player player;

        protected PlayerState(Player player) => this.player = player;

        public virtual bool ReadInput(InputAction.CallbackContext context, InputCommand command) => false;

        #region Dependencies wrapper

        protected RaycastHit2D Grounded => player.Grounded;
        protected PlayerSettings Settings => player.settings;
        protected Rigidbody2D Rigidbody => player.rigidbody;
        protected PlayerInput Input => player.input;

        #endregion

        #region State machine

        protected bool ChangeState(PlayerState state)
        {
            if (!state) return false;
            player.StateMachine.ChangeState(state);
            return true;
        }

        #endregion

        #region States wrapper

        protected IdleState Idle => player.IdleState;
        protected RunState Run => player.RunState;
        protected JumpState Jump => player.JumpState;
        protected FallState Fall => player.FallState;
        protected HookState Hook => player.HookState;

        #endregion
    }
}
