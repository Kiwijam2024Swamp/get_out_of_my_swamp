using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoutWaveMovement: MonoBehaviour
{
    // Start is called before the first frame update
    public MicrophoneInput micInput;
    public float threshold = 0.1f;
    public float distance = 5.0f;
    public float size = 10.0f;
    public float moveSpeed = 1.0f;
    public float activationInterval = 1.0f; // Time in seconds between activations

    private float lastActivationTime = 0f;
    private bool didActivate = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float volume = micInput.GetMicrophoneVolume();
        

        if (volume > threshold && Time.time - lastActivationTime >= activationInterval)
        {
            // Debug.Log("Sound detected!");
            Debug.Log("Loudness: " + volume);
            StartCoroutine(MoveSquare(volume));
            lastActivationTime = Time.time;
        }
    }

    IEnumerator MoveSquare(float volume)
    {
        float moveDuration = 0.5f; // Move for 1 second
        float elapsedTime = 0f;
        // Move the square object based on the volume
        while (elapsedTime < moveDuration)
        {
            transform.Translate(Vector3.up * moveSpeed * volume * distance *Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //Destroy(this.gameObject);
    }
}
