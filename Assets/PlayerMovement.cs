using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [FormerlySerializedAs("force")] public float bodyForce = 10;
    [Range(0, 5)] public float bulletForceMultiplier = 2;
    public Vector2 movementInput;
    public bool triggered;

    public GameObject bullet;

    private new Rigidbody rigidbody;
    private new ParticleSystem particleSystem;

    private new Collider collider;
    private Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
        collider = GetComponent<Collider>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        rigidbody = GetComponent<Rigidbody>();
    }

    [UsedImplicitly]
    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (CanAct() == false) return;

        movementInput = ctx.ReadValue<Vector2>();
        if (movementInput == Vector2.zero) return;
        float angleA = 0;
        if (Mathf.Atan2(movementInput.x, movementInput.y) * Mathf.Rad2Deg != 0)
        {
            angleA = Mathf.Atan2(movementInput.x, movementInput.y) * Mathf.Rad2Deg;
        }

        transform.eulerAngles = new Vector3(0, angleA + 90, 0);
    }

    [UsedImplicitly]
    public void OnShoot(InputAction.CallbackContext ctx)
    {
        if (CanAct() == false) return;
        triggered = ctx.action.WasPerformedThisFrame();
        if (!triggered) return;
        rigidbody.AddForce(-transform.forward * bodyForce, ForceMode.VelocityChange);
        particleSystem.Emit(10);

        GameObject bulletInstance = Instantiate(bullet);
        bulletInstance.transform.SetPositionAndRotation(transform.position + transform.forward, transform.rotation);

        Physics.IgnoreCollision(bulletInstance.GetComponent<Collider>(), collider);

        Rigidbody bulletRigidbody = bulletInstance.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(transform.forward * bodyForce * bulletForceMultiplier, ForceMode.VelocityChange);
    }


    private bool CanAct() => player.State.Statue == PlayerStateMachine.StateEnum.Alive;
}