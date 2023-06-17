using System;
using System.Globalization;
using Game;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UiManager : MonoBehaviour
{
    [Header("Wait")]
    public GameObject Wait;

    public TMP_Text WaitText;

    [Header("Play")]
    public GameObject Play;

    [Header("Game Over")]
    public GameObject GameOver;


    public GameObject PlayerUiPrefab;
    [FormerlySerializedAs("UiParent")] public RectTransform UiPlayerListParent;
    private GameManager m_gameManager;

    private void Awake()
    {
        Player.OnPlayerConnect += OnNewPlayerSpawn;
        Player.OnPlayerDisconnect += OnPlayerDisconnect;
        m_gameManager = ((GameManager)GameManager.Instance);

        m_gameManager.StateMachine.OnPrepareState += OnPrepareState;
        m_gameManager.StateMachine.OnDestroyState += OnDestroyState;
    }

    private void OnDestroy()
    {
        Player.OnPlayerConnect -= OnNewPlayerSpawn;
        Player.OnPlayerDisconnect -= OnPlayerDisconnect;

        m_gameManager.StateMachine.OnPrepareState -= OnPrepareState;
        m_gameManager.StateMachine.OnDestroyState -= OnDestroyState;
    }

    private void OnPrepareState(BaseState a_state)
    {
        Wait.SetActive(a_state is WaitState);
        Play.SetActive(a_state is PlayState);
        GameOver.SetActive(a_state is GameOverState);
    }

    private void OnDestroyState(BaseState a_state)
    {
        Wait.SetActive(false);
        Play.SetActive(false);
        GameOver.SetActive(false);
    }


    private void OnPlayerDisconnect(Player a_player)
    {
        if (!m_gameManager.PlayerToUi.ContainsKey(a_player)) return;
        Destroy(m_gameManager.PlayerToUi[a_player].gameObject);
        m_gameManager.PlayerToUi.Remove(a_player);
    }

    private void OnNewPlayerSpawn(Player a_player)
    {
        GameObject instance = Instantiate(PlayerUiPrefab, UiPlayerListParent);

        PlayerUiElement uiElement = instance.GetComponent<PlayerUiElement>();
        m_gameManager.PlayerToUi.Add(a_player, uiElement);

        uiElement.SetLink(a_player);
    }
}