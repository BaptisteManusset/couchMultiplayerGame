using Game;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [Header("Wait")]
    public GameObject Wait;

    [Header("Play")]
    public GameObject Play;

    [Header("Game Over")]
    public GameObject GameOver;


    private void Awake()
    {
        Player.OnPlayerDisconnect += OnPlayerDisconnect;

        GameManager.Instance.StateMachine.OnPrepareState += OnPrepareState;
        GameManager.Instance.StateMachine.OnDestroyState += OnDestroyState;
    }

    private void OnDestroy()
    {
        Player.OnPlayerDisconnect -= OnPlayerDisconnect;

        if (GameManager.Instance)
        {
            GameManager.Instance.StateMachine.OnPrepareState -= OnPrepareState;
            GameManager.Instance.StateMachine.OnDestroyState -= OnDestroyState;
        }
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
        if (!GameManager.Instance.PlayerToUi.ContainsKey(a_player)) return;
        Destroy(GameManager.Instance.PlayerToUi[a_player].gameObject);
        GameManager.Instance.PlayerToUi.Remove(a_player);
    }
}