using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform target;
    public float smoothOffset;
    public Vector3 offset;

    void Update()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, target.position + offset, smoothOffset);
        transform.position = newPosition;
    }
}
