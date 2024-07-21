using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SwitchToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        // If running in the Unity editor, stop playing the scene.
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
