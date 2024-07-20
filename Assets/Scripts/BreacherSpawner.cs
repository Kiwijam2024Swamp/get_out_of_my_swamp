using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BreacherSpawner : MonoBehaviour
{
    public float xrange;
    public float yrange;
    public GameObject[] breachers;
    public float spawnInterval = 2.0f;
    private float currentTime;

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
        Vector2 spawnPos = new Vector2(Random.Range(transform.position.x - xrange, transform.position.x + xrange), Random.Range(transform.position.y - yrange, transform.position.y + yrange));
        int breacherIndex = Random.Range(0, breachers.Length);
        Instantiate(breachers[breacherIndex], spawnPos, Quaternion.identity);
    }
}
