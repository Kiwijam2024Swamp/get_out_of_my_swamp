using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoutWaveMovement: MonoBehaviour
{

    public float size = 0.05f;
    public float moveSpeed = 10.0f;
    // public Vector2 position;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator MoveSquare(float volume, Vector2 position, float direction)
    {
        // Create(this.gameObject);
        float moveDuration = 0.5f; // Move for 1 second
        float elapsedTime = 0f;
        transform.localPosition = position;
        transform.localR

        // Move the square object based on the volume
        while (elapsedTime < moveDuration)
        {
            transform.Translate(Vector3.up * moveSpeed * volume * Time.deltaTime);
            Vector2 scale = transform.localScale;
            scale.x += size; 
            transform.localScale = scale;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(this.gameObject);
    }
}
