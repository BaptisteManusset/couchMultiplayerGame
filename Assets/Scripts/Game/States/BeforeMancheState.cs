using UnityEngine;

public class BeforeMancheState : BaseState
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