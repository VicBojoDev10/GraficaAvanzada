using Unity.VisualScripting;
using UnityEngine;

public class CubeDamage : MonoBehaviour
{
    public int damageToDeal; 
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<MainPlayer>().ReceiveDamage(damageToDeal);
    }
}
