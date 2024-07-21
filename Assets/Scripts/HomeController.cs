using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class HomeController : MonoBehaviour
{
    private int _breacherCount = 0;
    public int maxBreacherCount = 10;
    private bool isDoneWaiting = false;
    private bool gameOver = false;
    public GameObject gameOverSprite; // Reference to the GameObject with the sprite
    private SpriteRenderer spriteRenderer;
    public float fadeDuration = 1f; // Duration of the fade
    private float fadeTimer = 0f;



    //HP Related UI
    [SerializeField] private TextMeshProUGUI _breachText;
    [SerializeField] private Slider _breachSlider;

    // Start is called before the first frame update
    void Start()
    {
        _breacherCount = 0;
        _breachSlider.value = 0;
        _breachSlider.maxValue = maxBreacherCount;

        // spriteRenderer = gameOverSprite.GetComponent<SpriteRenderer>();

        // Make sure the sprite starts fully invisible
        Color color = spriteRenderer.color;
        color.a = 0f;
        spriteRenderer.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddBreacher();
        }

        _breachText.text = _breacherCount + "/" + maxBreacherCount;

        // Game over!!
        if (_breachSlider.value >= _breachSlider.maxValue)
        {
            GameOverWaiting();
        }
        if (isDoneWaiting == true)
        {
            SwitchToScene("TitleScreen");
        }

        // If game over, gradually increase opacity
        if (gameOver)
        {
            fadeTimer += Time.deltaTime;
            float alpha = Mathf.Clamp01(fadeTimer / fadeDuration);
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }
    }

    public void SwitchToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void AddBreacher()
    {
        _breacherCount++;
        _breachSlider.value = _breacherCount;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Breacher")
        {
            AddBreacher();
            Destroy(col.gameObject);
        }
    }

    IEnumerator GameOverWaiting()
    {
        gameOver = true;
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        isDoneWaiting = true;
    }
}
