using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrekAttack : MonoBehaviour
{
    public MicrophoneInput micInput;
    public GameObject waveObject;
    public Transform spawnPos;
    public float activationInterval = 1.0f; // Time in seconds between activations

    private ShrekController shrek;
    private float lastActivationTime = 0f;

    void Start()
    {
        shrek = GetComponent<ShrekController>();
    }

    void Update()
    {
        // Get the mouse position in world space
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0; // Ensure the z-coordinate is 0 if you're working in a 2D context

        // Calculate direction from shrek's position to the mouse position
        Vector2 direction = (mouseWorldPosition - shrek.transform.position).normalized;

        float volume = micInput.GetMicrophoneVolume();       

        if (volume > GameSettings.micThreshold && Time.time - lastActivationTime >= activationInterval)
        {
            GameObject instance = Instantiate(waveObject, spawnPos.position, Quaternion.identity);
            ShoutWaveMovement shoutWave = instance.GetComponent<ShoutWaveMovement>();

            if (shoutWave != null)
            {
                Debug.Log("Loudness: " + volume);
                StartCoroutine(shoutWave.MoveSquare(volume, spawnPos.position, direction));
                lastActivationTime = Time.time;
            }
            else
            {
                Debug.LogError("ShoutWaveMovement component not found on waveObject.");
            }
        }
    }
}
