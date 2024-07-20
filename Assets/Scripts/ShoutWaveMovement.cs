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

    public IEnumerator MoveSquare(float volume, Vector2 position, Vector2 direction)
    {
        // Create(this.gameObject);
        float moveDuration = 0.5f; // Move for 1 second
        float elapsedTime = 0f;
        transform.localPosition = position;
        
        RotateTowards(direction);

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

    void RotateTowards(Vector2 direction)
    {
        // Ensure the direction is normalized
        direction.Normalize();

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Create a quaternion from the angle
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        // Apply the rotation to the object
        transform.rotation = rotation;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Breacher")
        {
            BreacherController bc = col.GetComponent<BreacherController>();
            bc.TakeDamage(1);                                                //TODO: Modify this based on volume
        }
    }
}
