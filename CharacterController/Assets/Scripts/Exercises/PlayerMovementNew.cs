using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerMovementNew : MonoBehaviour, IMovable
{
    public float speed = 6f;
    public float gravity = -20f;


    private CharacterController controller;
    private float verticalVelocity;
    
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    public void Move(Vector2 direction)
    {
        if(controller.isGrounded && verticalVelocity < 0f)
           verticalVelocity = -2f;

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 movement  = new Vector3(direction.x, 0f, direction.y) ;  
        
        controller.Move(movement);
    }
}
