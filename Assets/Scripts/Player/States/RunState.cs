using UnityEngine;

namespace Player
{
    public class RunState : GroundedState
    {
        private float _velocity;
        public RunState(Player player) : base(player) { }

        public override void Update()
        {
            _velocity = Input.Direction * Settings.speed;
            if (Input.Direction <= Input.deadZone)
                ChangeState(Idle);
        }

        public override void FixedUpdate()
        {
            if (!player.hook.Grappling)
                Rigidbody.velocity = _velocity * Vector2.right;
        }

        public override string ToString() => nameof(RunState);
    }
}
