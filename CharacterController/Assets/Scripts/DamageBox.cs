using UnityEngine;

public class DamageBox : MonoBehaviour
{
    public int damageToDeal = 10;
    private void OnTriggerEnter(Collider collider)
    {
        collider.GetComponent<MainPlayer>().ReceiveDamage(damageToDeal);
    }
}
