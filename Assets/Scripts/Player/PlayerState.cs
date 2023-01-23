using StatePattern;
using UnityEngine.InputSystem;

namespace Player
{
    public abstract class PlayerState : State
    {
        protected readonly Player player;

        protected PlayerState(Player player) => this.player = player;

        public virtual bool ReadInput(InputAction.CallbackContext context, InputCommand command) => false;

        #region State machine

        protected bool ChangeState(PlayerState state)
        {
            if (!state) return false;
            player.StateMachine.ChangeState(state);
            return true;
        }

        #endregion

        #region States shortcuts

        protected IdleState Idle => player.IdleState;
        protected RunState Run => player.RunState;
        protected JumpState Jump => player.JumpState;

        #endregion
    }
}
