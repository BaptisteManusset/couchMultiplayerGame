using UnityEngine;

public class MancheState : TimedState
{
    [SerializeField] private BaseState m_nextState;


    public int duration = 10;

    internal override void PrepareState()
    {
        base.PrepareState();

        PlayerHelper.ChangePlayersStatue(PlayerStateMachine.StatueEnum.Alive);

        CountDown.SetDurationAndStart(duration);
    }


    public override void DestroyState()
    {
        base.DestroyState();
        PlayerHelper.ChangePlayersStatue(PlayerStateMachine.StatueEnum.Wait);
    }


    public override void UpdateState()
    {
        if (GameManager.Instance.Party.Players.Count == 0) return;

        if (CountDown.progress <= 0)
        {
            owner.ChangeState(m_nextState);
        }

        base.UpdateState();
    }
}