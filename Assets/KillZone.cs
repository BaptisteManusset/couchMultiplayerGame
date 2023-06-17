using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerCollider collider = other.GetComponent<PlayerCollider>();
        if (!collider) return;
        Player player = collider.GetComponentInParent<Player>();
        if (!player) return;
        player.Health.TakeDamage(-1000);
        other.GetComponent<Rigidbody>().isKinematic = true;
    }
}