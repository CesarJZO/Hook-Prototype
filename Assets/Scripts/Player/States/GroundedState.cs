using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public abstract class GroundedState : PlayerState
    {
        protected GroundedState(Player player) : base(player) { }

        public override void FixedUpdate()
        {
            if (!player.hook.Grappling)
                Rigidbody.AddForce(Input.Direction * Settings.speed * Vector2.right);
        }

        public override bool ReadInput(InputAction.CallbackContext context, InputCommand command)
        {
            return command switch
            {
                InputCommand.Jump => ChangeState(Jump),
                InputCommand.Shoot when context.performed => ChangeState(Hook),
                _ => false
            };
        }

        public override string ToString() => nameof(GroundedState);
    }
}
