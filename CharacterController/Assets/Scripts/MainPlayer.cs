using UnityEngine;
using UnityEngine.InputSystem;

public class MainPlayer : MonoBehaviour
{
    public delegate void OnPlayerDamaged(int currentHealth);
    public OnPlayerDamaged playerDamaged;

    public int health = 100;
    public float speed = 5f;
    public void Update()
    {
        Vector3 moveVector =
            new Vector3(
                Input.GetAxis("Horizontal"),
                0,
                Input.GetAxis("Vertical")) * Time.deltaTime * 5f;
        transform.Translate(moveVector);
    }
    public void ReceiveDamage(int damage)
    {
        health -= damage;
        playerDamaged?.Invoke(health);
    }
}
