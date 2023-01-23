namespace Player
{
    public class FallState : PlayerState
    {
        public FallState(Player player) : base(player) { }

        public override void FixedUpdate()
        {
            if (Grounded)
                ChangeState(Run);
        }

        public override string ToString() => nameof(FallState);
    }
}
