using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreacherController : MonoBehaviour
{
    public float speed = 5.0f;
    public float maxHealth = 3.0f;
    private Transform _targetPos;

    private float _health;



    // Start is called before the first frame update
    void Start()
    {
        _health = maxHealth;
        _targetPos = GameObject.FindGameObjectWithTag("BreacherTarget").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPos.position, speed * Time.deltaTime);

        if(_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
    } 
}
