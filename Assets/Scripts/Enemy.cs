using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float range = 1f;
    [SerializeField] private int damage = 5;
    [SerializeField] private float speed = 1f;
    [SerializeField] private Transform playerPos;
    private CircleCollider2D rangeCollider;
    private bool inPlayerRange;

    private void Start()
    {
        rangeCollider = GetComponent<CircleCollider2D>();
        rangeCollider.radius = range;
    }

    private void Update()
    {
        if (inPlayerRange && Movement.instance.isAttacking)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            ChasePlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            AttackPlayer();
        }
    }

    public void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        
    }

    public void AttackPlayer()
    {
        GameManager.instance.RemoveMoney(damage);
    }
}