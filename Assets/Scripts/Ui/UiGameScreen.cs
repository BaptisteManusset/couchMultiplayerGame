using System;
using Game;
using UnityEngine;
using UnityEngine.UI;

public class UiGameScreen : MonoBehaviour
{
    private PlayState m_playState;
    [SerializeField] private Image m_countdown;

    private UiListPlayers m_listPlayers;

    private void Awake()
    {
        m_listPlayers = GetComponent<UiListPlayers>();
    }

    private void OnEnable()
    {
        m_playState = GameManager.Instance.StateMachine.CurrentState as PlayState;
        if (m_playState == null) gameObject.SetActive(false);
        m_listPlayers.DisplayPlayers(GameManager.Instance.Party.Players);
    }

    private void Update()
    {
        m_countdown.fillAmount = m_playState.CountDown.normalizedProgress;
    }

    private void OnDestroy()
    {
        m_listPlayers.Clear();
    }
}