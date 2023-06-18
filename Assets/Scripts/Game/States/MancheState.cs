using UnityEngine;

public class MancheState : BaseState
{
    [SerializeField] private BaseState m_nextState;

    internal override void PrepareState()
    {
        base.PrepareState();

        Invoke(nameof(Chnage), 1);
    }

    private void Chnage()
    {
        owner.ChangeState(m_nextState);
    }
}