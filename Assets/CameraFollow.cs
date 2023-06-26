using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offSet = new Vector3(0f, 0f, -10f);
    private float smoothness = 0.30f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offSet;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothness);
    }
}
