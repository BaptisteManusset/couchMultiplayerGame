using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    private void OnCollisionEnter(Collision a_other)
    {
        BulletController bullet = a_other.gameObject.GetComponent<BulletController>();
        if (!bullet) return;

        player.Health.TakeDamage(1);
        Destroy(a_other.gameObject);
    }
}