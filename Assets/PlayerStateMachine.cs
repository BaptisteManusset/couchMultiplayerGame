using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public delegate void PlayerStateEvent(StateEnum a_state);

    public PlayerStateEvent OnPlayerStateEvent;

    public enum StateEnum
    {
        Wait,
        Alive,
        Dead
    }


    [SerializeField] private StateEnum m_statue = StateEnum.Wait;

    public StateEnum Statue => m_statue;

    public void SetStatue(StateEnum a_state)
    {
        if (m_statue == a_state) return;

        m_statue = a_state;
        OnPlayerStateEvent?.Invoke(m_statue);
    }
}