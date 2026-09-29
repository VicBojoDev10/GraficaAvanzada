using UnityEngine;
using Unity.Cinemachine;

public class CineMachineLook : MonoBehaviour, ILookable
{
    [SerializeField] private CinemachineOrbitalFollow orbitalFollow;
    [SerializeField] private float sensivity = 0.15f;

    public void Look(Vector2 delta)
    {
        orbitalFollow.HorizontalAxis.Value += delta.x * sensivity;
        float vertical = orbitalFollow.VerticalAxis.Value - delta.y * sensivity;
        Vector2 range = orbitalFollow.VerticalAxis.Range;
        orbitalFollow.VerticalAxis.Value = Mathf.Clamp( vertical, range.x, range.y);
    }
    
}
