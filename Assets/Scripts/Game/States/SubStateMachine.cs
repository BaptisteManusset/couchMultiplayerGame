using Game;
using NaughtyAttributes;
using UnityEngine;

public class SubStateMachine : GameStateMachine
{
    [ReadOnly] [SerializeField] private ParentStateMachineBaseState OwnerState;

    public override void Awake()
    {
        base.Awake();
        if (OwnerState == null) OwnerState = GetComponent<ParentStateMachineBaseState>();
    }

    public void EndStateMachine()
    {
        OwnerState.NextState();
    }
}