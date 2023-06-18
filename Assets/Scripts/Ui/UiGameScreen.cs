using UnityEngine;
using UnityEngine.UI;

public class UiGameScreen : MonoBehaviour
{
    [SerializeField] private TimedState m_timedState;
    [SerializeField] private Image m_countdown;

    [SerializeField] private UiListPlayers m_listPlayers;

    private void OnEnable()
    {
        if (m_listPlayers) m_listPlayers.DisplayPlayers(GameManager.Instance.Party.Players);
    }

    private void Update()
    {
        m_countdown.fillAmount = m_timedState.CountDown.normalizedProgress;
    }

    private void OnDestroy()
    {
        m_listPlayers.Clear();
    }
}