using UnityEngine;

namespace Player
{
    public class FallState : PlayerState
    {
        private float _input;

        public FallState(Player player) : base(player) { }

        public override void Update()
        {
            _input = Input.Direction * Settings.AirInputInfluence * Settings.Speed;
        }

        public override void FixedUpdate()
        {
            Rigidbody.velocity = new Vector2(_input, Rigidbody.velocity.y);
            if (Grounded)
                ChangeState(Run);
        }

        public override string ToString() => nameof(FallState);
    }
}
