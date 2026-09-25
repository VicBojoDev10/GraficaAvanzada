using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputReader inputReader;
    private IMovable movement;
    private void Awake()
    {
        inputReader = GetComponent<PlayerInputReader>();
        movement = GetComponent<IMovable>();
    }
    void Update()
    {
        movement.Move(inputReader.moveInput);
    }
}
