using System.Globalization;
using Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiWaitScreen : MonoBehaviour
{
    private WaitState m_waitState;
    [SerializeField] private Image m_countdown;

    [SerializeField]
    private TMP_Text m_countdownText;

    [SerializeField] private TMP_Text m_playerNumber;

    private void OnEnable()
    {
        m_waitState = GameManager.Instance.StateMachine.CurrentState as WaitState;

        if (m_waitState == null)
        {
            gameObject.SetActive(false);
        }

        Player.OnPlayerConnect += OnPlayerCountChange;
        Player.OnPlayerDisconnect += OnPlayerCountChange;

        UpdatePlayerNumber();
    }

    private void OnPlayerCountChange(Player a_player) => UpdatePlayerNumber();

    private void UpdatePlayerNumber()
    {
        m_playerNumber.text = $"{GameManager.Instance.Party.Players.Count} joueurs";
    }

    private void OnDisable()
    {
        Player.OnPlayerConnect -= OnPlayerCountChange;
        Player.OnPlayerDisconnect -= OnPlayerCountChange;
    }

    private void FixedUpdate()
    {
        m_countdown.fillAmount = m_waitState.CountDown.normalizedProgress;

        int value = Mathf.RoundToInt(m_waitState.CountDown.progress);
        m_countdownText.text = value != 0 ? value.ToString(CultureInfo.InvariantCulture) : "Go !!!";
    }
}