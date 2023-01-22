namespace Player
{
    public class IdleState : PlayerState
    {
        public IdleState(Player player) : base(player) { }

        public override string ToString() => nameof(IdleState);
    }
}
