using UnityEngine;

public class StateMachine : MonoBehaviour
{
    // Reference to currently operating state.
    private BaseState currentState;
    public BaseState CurrentState => currentState;

    public delegate void StateMachineEvent(BaseState a_state);

    public StateMachineEvent OnDestroyState;
    public StateMachineEvent OnPrepareState;


    public virtual void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    public void ChangeState(BaseState newState)
    {
        if (currentState != null)
        {
            currentState.DestroyState();
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.owner = this;
            currentState.PrepareState();
        }
    }
}