using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Transform playerPos;
    private Transform spawnPos;
    private bool inCollider;

    private void Awake()
    {
        GameObject home = GameObject.Find("TeleporterHome");
        spawnPos = home.transform;
        GameObject player = GameObject.Find("Drill");
        playerPos = player.transform;
    }

    private void Update()
    {

        if (inCollider && Input.GetKeyDown(KeyCode.W))
        {
            playerPos.transform.position = spawnPos.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            inCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            inCollider = false;
        }
    }
}
