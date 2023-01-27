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

        public override void Update()
        {
            if (Input.Direction != 0f)
                ChangeState(Run);
        }

        public override void FixedUpdate()
        {
            if (Rigidbody.velocity.magnitude >= Input.deadZone)
                ChangeState(Run);
            else if (!Grounded)
                ChangeState(Fall);
        }

        public override string ToString() => nameof(IdleState);
    }
}
