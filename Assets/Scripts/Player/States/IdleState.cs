namespace Player
{
    public class IdleState : GroundedState
    {
        public IdleState(Player player) : base(player) { }

        public override string ToString() => nameof(IdleState);
    }
}
