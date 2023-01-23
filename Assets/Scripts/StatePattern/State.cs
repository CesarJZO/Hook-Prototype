namespace StatePattern
{
    public abstract class State
    {
        public virtual void OnStartState() { }
        public virtual void OnEndState() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }

        public static implicit operator bool(State state) => state != null;
    }
}
