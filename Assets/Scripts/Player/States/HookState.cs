using UnityEngine.InputSystem;

namespace Player
{
    public class HookState : PlayerState
    {
        public HookState(Player player) : base(player) { }

        public override void FixedUpdate()
        {
            if (Grounded && !Input.holdShoot)
                ChangeState(Run);
        }

        public override bool ReadInput(InputAction.CallbackContext context, InputCommand command)
        {
            if (command == InputCommand.Shoot && context.canceled)
                ChangeState(Fall);
            return false;
        }

        public override string ToString() => nameof(HookState);
    }
}
