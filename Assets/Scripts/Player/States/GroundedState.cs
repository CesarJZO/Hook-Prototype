using UnityEngine.InputSystem;

namespace Player
{
    public abstract class GroundedState : PlayerState
    {
        protected GroundedState(Player player) : base(player) { }

        public override bool ReadInput(InputAction.CallbackContext context, InputCommand command)
        {
            return command switch
            {
                InputCommand.Jump => ChangeState(Jump),
                _ => false
            };
        }

        public override string ToString() => nameof(GroundedState);
    }
}
