using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrekAttack : MonoBehaviour
{
    public MicrophoneInput micInput;
    private ShoutWaveMovement shoutWave;
    // public float threshold = 0.3f;
    private Vector2 direction;

    public float activationInterval = 1.0f; // Time in seconds between activations
    private float lastActivationTime = 0f;
    public GameObject waveObject;
    public Transform spawnPos;

    private ShrekController shrek;

    void Start()
    {
        shrek = GetComponent<ShrekController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = shrek.direction;
        float volume = micInput.GetMicrophoneVolume();       

        if (volume > GameSettings.micThreshold && Time.time - lastActivationTime >= activationInterval)
        {
            GameObject instance = Instantiate(waveObject, spawnPos.position, Quaternion.identity);
            shoutWave = instance.GetComponent<ShoutWaveMovement>();
            // Debug.Log("Sound detected!");
            Debug.Log("Loudness: " + volume);
            StartCoroutine(shoutWave.MoveSquare(volume, spawnPos.position, direction));
            lastActivationTime = Time.time;
        }
    }
}
