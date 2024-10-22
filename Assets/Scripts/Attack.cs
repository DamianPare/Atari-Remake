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

    public event Action hitEnemy;

    void Update()
    {
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
        else if(collision.gameObject.layer == 6)
        {
            Destroy(collision.gameObject);
            returning = true;
        }
    }
}
