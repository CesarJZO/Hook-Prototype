namespace Player
{
    public class RunState : GroundedState
    {
        public RunState(Player player) : base(player) { }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (Rigidbody.velocity.magnitude >= Input.deadZone)
                ChangeState(Idle);
        }

        public override string ToString() => nameof(RunState);
    }
}
