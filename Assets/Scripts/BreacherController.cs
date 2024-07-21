using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreacherController : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb;  
    public float speed = 5.0f;
    public float maxHealth = 3.0f;
    private Transform _targetPos;
    private Transform _offscreenTargetPos;
    private float _health;
    private Boolean _damageEffect;



    // Start is called before the first frame update
    void Start()
    {
        _health = maxHealth;
        _damageEffect = false;
        _targetPos = GameObject.FindGameObjectWithTag("BreacherTarget").transform;
        _offscreenTargetPos = GameObject.FindGameObjectWithTag("OffscreenBreacherTarget").transform;

        sr = this.GetComponentInChildren<SpriteRenderer>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_health > 0 && _damageEffect == false)
        {
            //Move towards house door
            transform.position = Vector2.MoveTowards(transform.position, _targetPos.position, speed * Time.deltaTime);
        } else {
            //Move away from house door
            transform.position = Vector2.MoveTowards(transform.position, _offscreenTargetPos.position, speed * Time.deltaTime);
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        _damageEffect = true;
        StartCoroutine(DamageEffect());
    } 

    IEnumerator DamageEffect()
    {
        speed = 0.0f;
        for(int i = 0; i < 3; i++)
            {
                sr.color = Color.red;
                yield return new WaitForSeconds (0.1f); 
                sr.color = Color.white;
                yield return new WaitForSeconds (0.1f); 
            }
        yield return new WaitForSeconds (0.5f); 
        speed = 5.0f;
        _damageEffect = false;
    }
}
