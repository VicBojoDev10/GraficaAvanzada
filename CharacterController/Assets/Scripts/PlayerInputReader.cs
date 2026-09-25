using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    public Vector2 moveInput {get; private set;}
    public InputAction moveAction;
    private void Awake()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
    }
    private void OnEnable()
    {
        moveAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
    }
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }
}
