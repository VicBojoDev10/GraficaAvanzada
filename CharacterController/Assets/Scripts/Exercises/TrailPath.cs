using System;
using System.Collections.Generic;
using UnityEngine;

public class TrailPath : MonoBehaviour
{
    public float speed = 1f;
    public float gravity = -2f;
    public Vector3 force;
    public GameObject[] checks = new GameObject[0];

    void FixedUpdate()
    {
        SeekBehaviour();
    }

    private void MoveTargets()
    {
        foreach (GameObject check in checks)
        {
            
        }
    }
    public Vector3 SeekBehaviour()
    {
        Vector3 movement = force * speed;
        Vector3 velocity = movement / gravity;
        return velocity;
    }
}
