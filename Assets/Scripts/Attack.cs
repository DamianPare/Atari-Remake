using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float distance = 10f;
    public float speed = 5f;
    public Transform player;

    private Vector3 targetPosition;
    private bool returning = false;
    public float spinSpeed = 1;

    private int bLevel;
    private int mLevel;
    private GameObject block;

    public event Action hitEnemy;
    public event Action blockDestroyed;
    public event Action blockRestricted;
    public event Action attackPerformed;

    private void Start()
    {
        mLevel = 0;
    }

    void Update()
    {
        mLevel = GameManager.instance.miningLevel;

        transform.Rotate(new Vector3(0, 0, 100) * Time.deltaTime * spinSpeed);
        
        if (!returning && targetPosition != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                returning = true; 
            }
        }

        if (returning)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, player.position) < 0.1f)
            {
                returning = false;
                targetPosition = Vector3.zero;
                gameObject.SetActive(false);
            }
        }
    }

    void ThrowPickaxe()
    {
        Vector3 forwardDirection = Movement.instance.moveDir;
        targetPosition = player.position + forwardDirection * distance;
        returning = false;
    }

    private void OnEnable()
    {
        transform.position = player.position;
        ThrowPickaxe();
        attackPerformed?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.layer == 8)
        {
            Destroy(collision.gameObject);
            hitEnemy?.Invoke();
            returning = true;
        }
        else if (collision.gameObject.layer == 6)
        {
            Destroy(collision.gameObject);
            returning = true;

            block = collision.gameObject;
            bLevel = block.GetComponent<Block>().blockLevel;
            if (mLevel > bLevel)
            {
                Destroy(block);
                blockDestroyed?.Invoke();
            }

            else if (mLevel == bLevel)
            {
                bLevel--;
            }

            else
            {
                blockRestricted?.Invoke();
            }
        }
    }
}