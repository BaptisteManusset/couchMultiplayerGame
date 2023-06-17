using UnityEngine;

public class StateModifier
{
    protected BaseState state;

    protected StateModifier(BaseState a_state)
    {
        state = a_state;
    }

    public virtual void PrepareState() { }

    public virtual void UpdateState() { }

    public virtual void DestroyState() { }
}