using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BreacherSpawner : MonoBehaviour
{

    public Vector2 spawnPosition;

    public GameObject[] breachers;
    private float currentTime;

    private float _angle;
    private float _xPos;
    private float _yPos;
    public float radius = 10.0f;

    private GameManager _gm;

    void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentTime = _gm.spawnInterval;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            SpawnBreacher();
            currentTime = _gm.spawnInterval;
        }
    }

    void SpawnBreacher()
    {
        _angle = Random.Range(0, 360);
        _xPos = radius * Mathf.Cos(_angle);
        _yPos = radius * Mathf.Sin(_angle);

        Vector2 spawnPos = new Vector2(_xPos, _yPos);
        int breacherIndex = Random.Range(0, breachers.Length);
        Instantiate(breachers[breacherIndex], spawnPos, Quaternion.identity);
    }
}
