namespace Player
{
    public class RunState : PlayerState
    {
        public RunState(Player player) : base(player) { }

        public override string ToString() => nameof(RunState);
    }
}
