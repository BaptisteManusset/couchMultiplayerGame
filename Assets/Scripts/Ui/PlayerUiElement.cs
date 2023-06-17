using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUiElement : MonoBehaviour
{
    public Player currentPlayer;

    public Image Visual;
    public Image DeadIcon;
    public TMP_Text Name;
    public Image Health;

    private void Awake()
    {
        PlayerHealth.OnPlayerDied += OnPlayerDied;
        PlayerHealth.OnPlayerHealthChange += OnPlayerDied;
    }

    private void OnPlayerDied(Player a_player)
    {
        if (currentPlayer != a_player) return;
        UpdateUi();
    }

    private void UpdateUi()
    {
        Health.fillAmount = currentPlayer.Health.NormalizedHealth;
        DeadIcon.gameObject.SetActive(currentPlayer.Health.currentHealth <= 0);
    }


    public void SetLink(Player a_player)
    {
        currentPlayer = a_player;
        if (!currentPlayer) return;
        Visual.sprite = currentPlayer.Icon;
        Name.text = currentPlayer.Name;
        Health.fillAmount = currentPlayer.Health.NormalizedHealth;
        UpdateUi();
    }
}