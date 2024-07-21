using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpriteSwitcher : MonoBehaviour
{
    private MicrophoneInput micInput;
    public Image targetImage;
    public Sprite micOffSprite;
    public Sprite micOnSprite;
    public float delay = 0.30f;

    public Image full;

    private Coroutine spriteChangeCoroutine;
    public GameObject shrekSprite; // GameObject for the random sprite
    public RectTransform canvasRectTransform; // Reference to the canvas RectTransform
    private SpriteRenderer shrekSpriteRenderer;

    void Start()
    {
        micInput = GetComponent<MicrophoneInput>();
        shrekSpriteRenderer = shrekSprite.GetComponent<SpriteRenderer>();
        shrekSpriteRenderer.enabled = false; // Start with the sprite hidden
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
            ChangeMicSprite(micOnSprite);
            ShowShrekSprite(true);
        }
        else
        {
            if (spriteChangeCoroutine == null)
            {
                spriteChangeCoroutine = StartCoroutine(DelayedHideShrekSprite());
                spriteChangeCoroutine = StartCoroutine(DelayedSpriteChange());
                ChangeMicSprite(micOffSprite);
            }
        }
    }

    void ChangeMicSprite(Sprite newSprite)
    {
        if (targetImage != null && targetImage.sprite != newSprite)
        {
            targetImage.sprite = newSprite;
        }
    }

    void ShowShrekSprite(bool makeVisible)
    {
        shrekSpriteRenderer.enabled = makeVisible;

        if (makeVisible)
        {
            Vector2 randomPosition = GetRandomPosition();
            shrekSprite.transform.position = randomPosition;
        }
    }

    IEnumerator DelayedHideShrekSprite()
    {
        yield return new WaitForSeconds(delay);
        ShowShrekSprite(false);
        
    }

    IEnumerator DelayedSpriteChange()
    {
        yield return new WaitForSeconds(delay);
        spriteChangeCoroutine = null;
    }


    Vector2 GetRandomPosition()
    {
        // Get random position within the canvas
        float randomX = Random.Range(-canvasRectTransform.rect.width / 2, canvasRectTransform.rect.width / 2);
        float randomY = Random.Range(- canvasRectTransform.rect.height / 2, canvasRectTransform.rect.height / 2);

        // Convert to world position
        Vector2 worldPosition = canvasRectTransform.TransformPoint(new Vector2(randomX, randomY));
        return worldPosition;
    }
}
