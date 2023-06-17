using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void PlayerEvent(Player a_player);

    public static PlayerEvent OnPlayerConnect;
    public static PlayerEvent OnPlayerDisconnect;
    private PlayerHealth m_health;
    public PlayerHealth Health => Tools.Get(ref m_health, GetComponent<PlayerHealth>());
    private PlayerStateMachine m_state;
    public PlayerStateMachine State => Tools.Get(ref m_state, GetComponent<PlayerStateMachine>());


    public Sprite Icon;
    public string Name;

    private void Awake()
    {
        OnPlayerConnect?.Invoke(this);

        PlayerHealth.OnPlayerDied += OnPlayerDied;
    }

    private void OnPlayerDied(Player a_player)
    {
        if (a_player != this) return;

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        OnPlayerDisconnect?.Invoke(this);
    }
}