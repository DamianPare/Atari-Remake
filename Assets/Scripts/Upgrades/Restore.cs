using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restore : Shop
{
    private bool inCollider;
    private void Update()
    {
        money = GameManager.instance.money;

        if (inCollider && Input.GetKeyDown(KeyCode.W))
        {
            if (money >= upgradeCost)
            {
                GameManager.instance.RemoveMoney(upgradeCost);
                GameManager.instance.RestoreHealth();
                Debug.Log("healed");
            }

            else
            {
                Debug.Log("Not Enough Money");
            }
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
