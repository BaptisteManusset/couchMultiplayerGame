using UnityEngine;

public class ObjectAttraction : MonoBehaviour
{
    public float attractionForce = 10f;
    public float attractionRange = 5f;

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attractionRange);

        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 direction = transform.position - collider.transform.position;
                float distance = direction.magnitude;
                float attractionFactor = 1f - distance / attractionRange; // Factor proportionnel à la distance
                Vector3 attractionForceVector = direction.normalized * attractionForce * attractionFactor;
                rb.AddForce(attractionForceVector);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attractionRange);
    }
}