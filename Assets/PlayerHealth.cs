using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Player player;

    public float maxHealth = 100;
    public float currentHealth;

    public float NormalizedHealth => Mathf.Max(0, currentHealth) / maxHealth;

    public delegate void PlayerHealthEvent(Player a_player);

    public static PlayerHealthEvent OnPlayerDied;
    public static PlayerHealthEvent OnPlayerHealthChange;

    private void Awake()
    {
        player = GetComponent<Player>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            OnPlayerHealthChange?.Invoke(player);
        }
    }

    private void Die()
    {
        OnPlayerDied?.Invoke(player);

        player.State.SetStatue(PlayerStateMachine.StateEnum.Dead);
        Debug.Log("Le joueur est mort !");
    }
}