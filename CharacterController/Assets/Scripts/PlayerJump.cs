using UnityEngine;
using UnityEngine.Rendering;

public class PlayerJump : MonoBehaviour , IJumpable
{
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravity = -20f;

    private CharacterController controller;
    private PlayerDash dash;
    private float verticalVelocity;
    public bool IsGrounded { get; private set; }
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        dash = GetComponent<PlayerDash>();
    }
    private void Update()
    {
        if (dash != null && dash.IsDashing)
        {
            verticalVelocity = 0f;
            return;
        }
        if (IsGrounded && verticalVelocity < 0f)
            verticalVelocity = -2f;
        verticalVelocity += gravity * Time.deltaTime;
        controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
        IsGrounded = controller.isGrounded; 
    }
    public void Jump(Vector3 up)
    {
        if (!IsGrounded)
        {
            return;
        }
        verticalVelocity = up.normalized.y * Mathf.Sqrt(jumpHeight * -2f * gravity);
        IsGrounded = false;
    }
}
