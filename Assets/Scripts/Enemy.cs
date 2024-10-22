using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float range = 1f;
    [SerializeField] private float damage = 0.1f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private Transform playerPos;
    private Vector3 spawnPos;
    private bool chasing;

    [SerializeField] private Sprite idle;
    [SerializeField] private Sprite trigger;
    [SerializeField] private SpriteRenderer ghostSprite;

    private void Awake()
    {
        spawnPos = transform.position;
        GameObject player = GameObject.Find("Drill");
        playerPos = player.transform;
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, playerPos.position) < range)
        {
            ChasePlayer();
        }

        if (Vector3.Distance(transform.position, playerPos.position) > range)
        {
            chasing = false;
        }

        if (!chasing && transform.position != spawnPos)
        {
            ReturnToSpawn();
        }

        ghostSprite.sprite = chasing ? trigger : idle;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            ChasePlayer();
            AttackPlayer();
        }
    }

    /*
    private void OnTriggerStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            AttackPlayer();
        }
    }
    */


    public void ChasePlayer()
    {
        chasing = true;
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    public void AttackPlayer()
    {
        Debug.Log("damaging");
        GameManager.instance.RemoveHealth(damage);
    }

    public void ReturnToSpawn()
    {
        transform.position = Vector3.MoveTowards(transform.position, spawnPos, speed * Time.deltaTime);
    }
}