using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpriteSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    private MicrophoneInput micInput;
    public Image targetImage;
    public Sprite micOffSprite;
    public Sprite micOnSprite;
    public float threshold = 0.1f;

    public Image full;

    private float volume = 0;

    void Start() 
    {
        micInput = GetComponent<MicrophoneInput>();
    }

    void Update()
    {
        if(micInput.GetMicrophoneVolume() != null)
        {
            volume = micInput.GetMicrophoneVolume();
        } 
        else
        {
            volume = 0.0f;
        }
        Debug.Log(volume);

        /*var temp = full.color;
        temp.a = volume;
        full.color = temp;*/


        if (volume > threshold)
        {
            ChangeSprite(micOnSprite);
        }
        else
        {
            ChangeSprite(micOffSprite);
        }
    }

    void ChangeSprite(Sprite newSprite)
    {
        if (targetImage != null && targetImage.sprite != newSprite)
        {
            targetImage.sprite = newSprite;
        }
    }
}
