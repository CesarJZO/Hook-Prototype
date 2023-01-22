using StatePattern;

namespace Player
{
    public abstract class PlayerState : State
    {
        protected readonly Player player;
        protected PlayerState(Player player) => this.player = player;

        protected PlayerState CurrentState => player.StateMachine.CurrentState as PlayerState;

        protected void ChangeState(PlayerState state) => player.StateMachine.ChangeState(state);

        protected IdleState Idle => player.IdleState;
        protected RunState Run => player.RunState;
    }
}
