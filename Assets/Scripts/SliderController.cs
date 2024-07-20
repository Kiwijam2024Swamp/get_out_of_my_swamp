using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderController : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider thresholdSlider;

    void Start()
    {
        // Initialize the slider value to the current threshold
        thresholdSlider.value = GameSettings.micThreshold;

        // Add a listener to call the OnSliderValueChanged method when the slider value changes
        thresholdSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float value)
    {
        // Update the micThreshold value in the GameSettings class
        GameSettings.micThreshold = value;
    }
}
