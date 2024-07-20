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
    // public float threshold = 0.1f;
    public float delay = 0.30f;

    public Image full;

    private float volume = 0;
    private Coroutine spriteChangeCoroutine;

    void Start() 
    {
        micInput = GetComponent<MicrophoneInput>();
    }

    void Update()
    {
        float volume = micInput.GetMicrophoneVolume();
        if (volume > GameSettings.micThreshold)
        {
            if (spriteChangeCoroutine != null)
            {
                StopCoroutine(spriteChangeCoroutine);
                spriteChangeCoroutine = null;
            }
            ChangeSprite(micOnSprite);
        }
        else
        {
            if (spriteChangeCoroutine == null)
            {
                spriteChangeCoroutine = StartCoroutine(DelayedSpriteChange());
            }
        }
    }

    void ChangeSprite(Sprite newSprite)
    {
        if (targetImage != null && targetImage.sprite != newSprite)
        {
            targetImage.sprite = newSprite;
        }
    }

    IEnumerator DelayedSpriteChange()
    {
        yield return new WaitForSeconds(delay);
        ChangeSprite(micOffSprite);
        spriteChangeCoroutine = null;
    }
}
