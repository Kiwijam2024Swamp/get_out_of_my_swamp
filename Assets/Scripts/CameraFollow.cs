using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset between the camera and the player
    public float smoothSpeed = 0.125f; // Smoothing speed for camera movement

    void FixedUpdate()
    {
        // Desired position is the player's position plus the offset
        Vector3 desiredPosition = player.position + offset;
        
        // Smoothly interpolate to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Update the camera's position
        transform.position = smoothedPosition;
    }
}
