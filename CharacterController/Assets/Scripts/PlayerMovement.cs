using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour, IMovable
{
    public float speed;
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();   
    }
    public void Move(Vector2 direction)
    {
        Vector3 movement = new Vector3(direction.x, 0f, direction.y) * speed;
        controller.Move(movement * Time.deltaTime);
    }
}
