using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MicThreshold
{
    // Start is called before the first frame update
    public float threshold = 0.4;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateThreshold(float newThreshold)
    {
        threshold = newThreshold;
    }
}
