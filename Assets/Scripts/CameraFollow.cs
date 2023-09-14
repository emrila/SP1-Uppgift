using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0,0,-10);
    [SerializeField] private float smooting;

    private void LateUpdate()
    {
        // Liniar interporlation
        // start pos, target pos, delay. 
        Vector3 newPosition = Vector3.Lerp(transform.position, target.position + offset, smooting);
        transform.position = newPosition;
    }
}
