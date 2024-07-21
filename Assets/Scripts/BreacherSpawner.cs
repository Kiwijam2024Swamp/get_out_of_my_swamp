using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BreacherSpawner : MonoBehaviour
{
    // public float xrange;
    // public float yrange;

    public Vector2 spawnPosition;


    public GameObject[] breachers;
    public float spawnInterval = 2.0f;
    private float currentTime;

    private float _angle;
    private float xPos;
    private float _yPos;
    private float radius = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(currentTime > 0) {
            currentTime -= Time.deltaTime;
        } else {
            SpawnBreacher();
            currentTime = spawnInterval;
        }
    }

    void SpawnBreacher () 
    {
        _angle = Random.Range(0, 360);
        xPos = radius * Mathf.Cos(_angle);
        _yPos = radius * Mathf.Sin(_angle);

        Vector2 spawnPos = new Vector2(xPos, _yPos);
        int breacherIndex = Random.Range(0, breachers.Length);
        Instantiate(breachers[breacherIndex], spawnPos, Quaternion.identity);
    }
}
