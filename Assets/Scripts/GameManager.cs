using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float score;
    public float spawnInterval;

    private float _difficultyTimer;
    public float startDifficultyTimer;

    [SerializeField] private TextMeshProUGUI _scoreText;

    public void Start()
    {
        _difficultyTimer = startDifficultyTimer;
    }

    public void Update()
    {
        _scoreText.text = "Score: " + score;

        if (_difficultyTimer <= 0)
        {
            spawnInterval -= 0.5f;
            _difficultyTimer = startDifficultyTimer;
        }
        else
        {
            _difficultyTimer -= Time.deltaTime;
        }

        if (spawnInterval < 0)
        {
            spawnInterval = 0;
        }
    }
}
