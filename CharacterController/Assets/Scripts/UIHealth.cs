using UnityEngine;
using UnityEngine.UI;
public class UIHealth : MonoBehaviour
{
    public MainPlayer mainPlayer;
    public Slider sliderHealth;

    void OnEnable()
    {
        mainPlayer = FindAnyObjectByType<MainPlayer>();
        mainPlayer.playerDamaged += OnPlayerReceivedDamage;
    }
    void OnDisable()
    {
        mainPlayer.playerDamaged -= OnPlayerReceivedDamage;
    }
    public void OnPlayerReceivedDamage(int health)
    {
        sliderHealth.value = health;
    }
}
