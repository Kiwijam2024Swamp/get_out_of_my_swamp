using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BreacherController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    public float speed = 5.0f;
    public float maxHealth = 3.0f;
    private Transform _targetPos;
    private Transform _offscreenTargetPos;
    private float _health;
    private Boolean _damageEffect;

    public AIDestinationSetter ds;

    private GameManager _gm;

    // Start is called before the first frame update
    void Start()
    {
        _health = maxHealth;
        _damageEffect = false;

        _targetPos = GameObject.FindGameObjectWithTag("BreacherTarget").transform;
        _offscreenTargetPos = GameObject.FindGameObjectWithTag("OffscreenBreacherTarget").transform;

        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        ds.target = _targetPos;

        sr = this.GetComponent<SpriteRenderer>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_health > 0 && _damageEffect == false)
        {
            //Move towards house door
            //transform.position = Vector2.MoveTowards(transform.position, _targetPos.position, speed * Time.deltaTime);
            ds.target = _targetPos;
        }
        else
        {
            //Move away from house door
            //transform.position = Vector2.MoveTowards(transform.position, _offscreenTargetPos.position, speed * Time.deltaTime);

            ds.target = _offscreenTargetPos;
        }

        CheckStatus();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        _damageEffect = true;
        StartCoroutine(DamageEffect());
    }

    public void CheckStatus()
    {
        if (_health <= 0)
        {
            _gm.score++;
            Destroy(gameObject);
        }
    }

    IEnumerator DamageEffect()
    {
        speed = 0.0f;
        for (int i = 0; i < 3; i++)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sr.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        speed = 5.0f;
        _damageEffect = false;
    }
}
