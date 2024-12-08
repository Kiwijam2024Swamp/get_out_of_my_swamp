using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class MicrophoneInput : MonoBehaviour
{
    private string microphone;
    private AudioClip micClip;
    private int sampleWindow = 128;

    void Start()
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
        Application.ExternalCall("requestMicrophone");
        #elif UNITY_ANDROID
        if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            InitializeMicrophone();
        }
        else
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
        #elif UNITY_IOS
        InitializeMicrophone();
        #else
        InitializeMicrophone();
        #endif
    }

    void OnApplicationFocus(bool focus)
    {
        #if UNITY_ANDROID
        if (focus && !Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
        #endif
    }

    void InitializeMicrophone()
    {
        // Check if there is at least one microphone available
        if (Microphone.devices.Length > 0)
        {
            // Use the first available microphone
            microphone = Microphone.devices[0];
            StartMicrophone();
        }
        else
        {
            Debug.LogWarning("No microphone found!");
        }
    }

    void StartMicrophone()
    {
        if (microphone != null)
        {
            micClip = Microphone.Start(microphone, true, 1, AudioSettings.outputSampleRate);
        }
    }

    public float GetMicrophoneVolume()
    {
        if (micClip == null || microphone == null)
            return 0;

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

    void OnDisable()
    {
        StopMicrophone();
    }

    void StopMicrophone()
    {
        if (microphone != null)
        {
            Microphone.End(microphone);
        }
    }
}
