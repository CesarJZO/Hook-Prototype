using UnityEngine;

namespace Player
{
    public class JumpState : PlayerState
    {
        public JumpState(Player player) : base(player) { }

        public override void OnStartState()
        {
            Rigidbody.AddForce(Vector2.up * Settings.jumpForce, ForceMode2D.Impulse);
        }

        public override void FixedUpdate()
        {
            if (Rigidbody.velocity.y <= 0f)
                ChangeState(Fall);
        }

        public override string ToString() => nameof(JumpState);
    }
}
