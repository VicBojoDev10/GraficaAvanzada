using UnityEngine;
using System.Collections;
public class PlayerDash : MonoBehaviour , IDashable
{
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashDuration = 0.15f;
    [SerializeField] private float dashCooldown = 0.5f;
    private CharacterController controller;
    private float nextDashTime;
    public bool IsDashing { get; private set; }
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Dash(Vector3 direction)
    {
        if(IsDashing || Time.time < nextDashTime) return;
        direction.y = 0f;
        if(direction == Vector3.zero) return;
        StartCoroutine(DashRoutine(direction.normalized));
    }

    private IEnumerator DashRoutine(Vector3 direction)
    {
        IsDashing = true;

        float elapsed = 0f;
        while (elapsed < dashDuration)
        {
            controller.Move(direction * dashSpeed * Time.deltaTime);
            elapsed += Time.deltaTime;
            yield return null;
        }

        IsDashing = false;
        nextDashTime = Time.time + dashCooldown;
    }
}
