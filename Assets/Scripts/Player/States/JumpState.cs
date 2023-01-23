namespace Player
{
    public class JumpState : PlayerState
    {
        public JumpState(Player player) : base(player) { }

        public override string ToString() => nameof(JumpState);
    }
}
