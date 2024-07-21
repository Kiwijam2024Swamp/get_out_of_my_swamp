using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BreacherController : MonoBehaviour
{
    public float speed = 5.0f;
    public float maxHealth = 3.0f;
    private Transform _targetPos;

    private float _health;

    private GameManager _gm;

    // Start is called before the first frame update
    void Start()
    {
        _health = maxHealth;
        _targetPos = GameObject.FindGameObjectWithTag("BreacherTarget").transform;
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameObject.GetComponent<AIDestinationSetter>().target = _targetPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPos.position, speed * Time.deltaTime);
        CheckStatus();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
    }

    public void CheckStatus()
    {
        if (_health <= 0)
        {
            _gm.score++;
            Destroy(gameObject);
        }
    }
}
