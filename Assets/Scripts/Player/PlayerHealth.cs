using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Player m_player;

    public float maxHealth = 100;
    public float currentHealth;

    public float NormalizedHealth => Mathf.Max(0, currentHealth) / maxHealth;

    public delegate void PlayerHealthEvent(Player a_player);

    public static PlayerHealthEvent OnPlayerDied;
    public static PlayerHealthEvent OnPlayerHealthChange;

    private void Awake()
    {
        m_player = GetComponent<Player>();
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
            OnPlayerHealthChange?.Invoke(m_player);
        }
    }

    private void Die()
    {
        OnPlayerDied?.Invoke(m_player);

        m_player.State.SetStatue(PlayerStateMachine.StatueEnum.Dead);
        Debug.Log("Le joueur est mort !");
    }
}