using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public delegate void PlayerStateEvent(StatueEnum a_statue);

    public PlayerStateEvent OnPlayerStateEvent;

    public enum StatueEnum
    {
        Wait,
        Alive,
        Dead
    }


    [SerializeField] private StatueEnum m_statue = StatueEnum.Wait;

    public StatueEnum Statue => m_statue;

    public void SetStatue(StatueEnum a_statue, bool a_force = false)
    {
        if (m_statue == a_statue) return;

        if (m_statue == StatueEnum.Dead && !a_force) return;

        m_statue = a_statue;
        OnPlayerStateEvent?.Invoke(m_statue);
    }
}