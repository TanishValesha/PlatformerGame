using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform cameraTransform;
    public float followspeed = 0.125f;
    public Vector3 Offset;
    public float endValue;
    
    private void FixedUpdate()
    {
        var position = cameraTransform.position;
        transform.position = new Vector2(Mathf.Clamp(position.x, -5f, endValue), 0);
        
        Vector3 desiredPosition = target.position + Offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, followspeed);
        transform.position = smoothPosition;
        
    }
}
