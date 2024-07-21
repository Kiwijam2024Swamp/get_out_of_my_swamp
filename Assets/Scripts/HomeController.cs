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

    //HP Related UI
    [SerializeField] private TextMeshProUGUI _breachText;
    [SerializeField] private Slider _breachSlider;

    // Start is called before the first frame update
    void Start()
    {
        _breacherCount = 0;
        _breachSlider.value = 0;
        _breachSlider.maxValue = maxBreacherCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddBreacher();
        }

        _breachText.text = _breacherCount + "/" + maxBreacherCount;

        // Game over!!
        if(_breachSlider.value >= _breachSlider.maxValue){


            SwitchToScene("TitleScreen");
        }
    }

    public void SwitchToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void AddBreacher() {
        _breacherCount++;
        _breachSlider.value = _breacherCount;
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Breacher") {
            AddBreacher();
            Destroy(col.gameObject);
        }
    }
}
