using UnityEngine;
using UnityEngine.Serialization;

public class ParentStateMachineBaseState : BaseState
{
    [SerializeField] private SubStateMachine SubStateMachine;
    [FormerlySerializedAs("m_baseState")] [SerializeField] private BaseState m_nextState;


    internal override void PrepareState()
    {
        base.PrepareState();

        // CountDown.SetDurationAndStart(5);
        SubStateMachine.StartStateMachine();
    }

    public void NextState()
    {
        owner.ChangeState(m_nextState);
    }
}