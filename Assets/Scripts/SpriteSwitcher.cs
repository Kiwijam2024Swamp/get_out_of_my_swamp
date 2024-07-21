using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitcher : MonoBehaviour
{
    private MicrophoneInput micInput;
    public Image targetImage;
    public Sprite micOffSprite;
    public Sprite micOnSprite;
    public float delay = 0.30f;

    private Coroutine spriteChangeCoroutine;
    public GameObject shrekSprite; // GameObject for the random sprite
    public RectTransform canvasRectTransform; // Reference to the canvas RectTransform
    private SpriteRenderer shrekSpriteRenderer;

    private bool isShrekVisible = false;

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
            if (!isShrekVisible)
            {
                ShowShrekSprite(true);
                isShrekVisible = true;
            }
        }
        else
        {
            if (spriteChangeCoroutine == null)
            {
                spriteChangeCoroutine = StartCoroutine(DelayedHideShrekSprite());
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
        if (makeVisible)
        {
            shrekSpriteRenderer.enabled = true;
            Vector2 randomPosition = GetRandomPosition();
            shrekSprite.transform.position = randomPosition;
        }
        else
        {
            shrekSpriteRenderer.enabled = false;
        }
    }

    IEnumerator DelayedHideShrekSprite()
    {
        yield return new WaitForSeconds(delay);
        ShowShrekSprite(false);
        ChangeMicSprite(micOffSprite);
        spriteChangeCoroutine = null;
        isShrekVisible = false;
    }

    Vector2 GetRandomPosition()
    {
        // Get random position within the canvas
        float randomX = Random.Range(-canvasRectTransform.rect.width / 2, canvasRectTransform.rect.width / 2);
        float randomY = Random.Range(-canvasRectTransform.rect.height / 2, canvasRectTransform.rect.height / 2);

        // Convert to world position
        Vector2 worldPosition = canvasRectTransform.TransformPoint(new Vector2(randomX, randomY));
        return worldPosition;
    }
}
