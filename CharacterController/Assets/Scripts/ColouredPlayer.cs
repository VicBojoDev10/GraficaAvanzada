using System.Collections;
using UnityEngine;

public class ColouredPlayer : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public MainPlayer mainPlayer;
    public Material materialOriginal;
    public Material materialNuevo;

    void OnEnable()
    {
        materialOriginal = GetComponent<Material>();
        materialNuevo = GetComponent<Material>();
        mainPlayer = FindAnyObjectByType<MainPlayer>();
        mainPlayer.playerDamaged += ChangingColorToPlayer;
    }
    void OnDisable()
    {
        mainPlayer.playerDamaged -= ChangingColorToPlayer;
    }
    public void ChangingColorToPlayer(int value)
    {
        StartCoroutine(CambiarColor());
    }
    public IEnumerator CambiarColor()
    {
        materialOriginal = materialNuevo;
        yield return new WaitForSeconds(5f);
        materialNuevo = materialOriginal;
    }
}
