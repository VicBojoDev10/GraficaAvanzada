using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumpInput : MonoBehaviour
{
    private PlayerInput playerInput;
    public InputAction jumpAction;
    public InputAction dashAction;
    private IDashable dashable;
    private Vector3 lastMoveDirection;
    private InputAction moveAction;
    private IJumpable jumpable;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        jumpable = GetComponent<IJumpable>();
        dashable = GetComponent<IDashable>();
        lastMoveDirection = transform.forward;
    }
    void Start()
    {
        jumpAction = playerInput.actions["Jump"];
        dashAction = playerInput.actions["Dash"];
        moveAction = playerInput.actions["Move"];
        jumpAction.performed += HandleJump;
        dashAction.performed += HandleDash;

    }
    private void OnDisable()
    {
        if (jumpAction != null) jumpAction.performed -= HandleJump;
        if (dashAction != null) dashAction.performed -= HandleDash;
    }
    private void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        if (input.sqrMagnitude > 0.01f)
            lastMoveDirection = new Vector3(input.x, 0f, input.y).normalized;
    }

    private void HandleJump(InputAction.CallbackContext ctx)
    {
        if(!enabled) return;
        jumpable?.Jump(Vector3.up);
    }

    private void HandleDash(InputAction.CallbackContext ctx)
    {
        if(!enabled) return;
        dashable?.Dash(lastMoveDirection);
    }

}
