using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrekController : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector2 direction { get; private set; }
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float movex = 0.0f;
        float movey = 0.0f;

        if (Input.GetKey(KeyCode.W))
        {
            movey += 1.0f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movey -= 1.0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movex -= 1.0f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movex += 1.0f;
        }

        direction = new Vector2(movex, movey).normalized;

        if (direction.x > 0)
        {
            sr.flipX = false;
        }
        else if (direction.x < 0)
        {
            sr.flipX = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = speed * direction * Time.deltaTime;
    }
}
