using Game;
using UnityEngine;

public class UiGameOverScreen : MonoBehaviour
{
    private GameOverState m_GameOverState;
    private UiListPlayers m_listPlayers;

    private void Awake()
    {
        m_listPlayers = GetComponent<UiListPlayers>();
    }

    private void OnEnable()
    {
        m_GameOverState = GameManager.Instance.StateMachine.CurrentState as GameOverState;
        if (m_GameOverState == null) gameObject.SetActive(false);

        m_listPlayers.DisplayPlayers(GameManager.Instance.Party.Winners);
    }

    private void OnDestroy()
    {
        m_listPlayers.Clear();
    }
}