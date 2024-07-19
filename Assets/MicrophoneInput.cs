using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MicrophoneInput : MonoBehaviour
{
    public string microphone;
    public float threshold = 0.1f;
    private AudioClip micClip;
    private int sampleWindow = 128;

    void Start()
    {
        // Use the default microphone
        if (microphone == null)
        {
            microphone = Microphone.devices[0];
        }
        StartMicrophone();
    }

    void Update()
    {
        if (IsMicrophoneInput())
        {
            Debug.Log("Sound detected!");
        }
    }

    void StartMicrophone()
    {
        micClip = Microphone.Start(microphone, true, 1, AudioSettings.outputSampleRate);
    }

    float GetMicrophoneVolume()
    {
        float[] data = new float[sampleWindow];
        int position = Microphone.GetPosition(microphone) - sampleWindow + 1;
        if (position < 0)
            return 0;
        micClip.GetData(data, position);

        float levelMax = 0;
        for (int i = 0; i < sampleWindow; i++)
        {
            float wavePeak = data[i] * data[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return Mathf.Sqrt(levelMax);
    }

    bool IsMicrophoneInput()
    {
        float volume = GetMicrophoneVolume();
        return volume > threshold;
    }

    void OnDisable()
    {
        StopMicrophone();
    }

    void StopMicrophone()
    {
        Microphone.End(microphone);
    }
}
