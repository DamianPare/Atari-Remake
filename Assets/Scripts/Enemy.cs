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
    private Vector3 spawnPos;
    private bool chasing;

    private void Awake()
    {
        spawnPos = transform.position;
        GameObject player = GameObject.Find("Drill");
        playerPos = player.transform;
    }

    private void Start()
    {
        rangeCollider = GetComponent<CircleCollider2D>();
        rangeCollider.radius = range;
    }

    private void Update()
    {
        if (!chasing && transform.position != spawnPos)
        {
            ReturnToSpawn();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            ChasePlayer();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            AttackPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        chasing = false;
    }

    public void ChasePlayer()
    {
        chasing = true;
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    public void AttackPlayer()
    {
        GameManager.instance.RemoveMoney(damage);
    }

    public void ReturnToSpawn()
    {
        transform.position = Vector3.MoveTowards(transform.position, spawnPos, speed * Time.deltaTime);
    }
}