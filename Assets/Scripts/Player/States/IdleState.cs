using UnityEngine;

namespace Player
{
    public class IdleState : GroundedState
    {
        public IdleState(Player player) : base(player) { }

        public override void OnStartState()
        {
            Rigidbody.velocity = Vector2.zero;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (Rigidbody.velocity.magnitude >= Input.deadZone)
                ChangeState(Run);
        }

        public override string ToString() => nameof(IdleState);
    }
}
