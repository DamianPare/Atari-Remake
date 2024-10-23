using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUP : Shop
{
    private bool inCollider;
    public TMP_Text cost;
    public GameObject helmet;
    private SpriteRenderer hat;

    private void Start()
    {
        cost.text = "$" + upgradeCost;
        hat = helmet.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        money = GameManager.instance.money;

        if (upgradeCost == 200)
        {
            hat.color = Color.cyan;
        }

        else if (upgradeCost == 400)
        {
            hat.color = Color.red;
        }

        else if (upgradeCost >= 800)
        {
            hat.color = Color.magenta;
        }


        if (inCollider && Input.GetKeyDown(KeyCode.W))
        {
            if (money >= upgradeCost)
            {
                GameManager.instance.RemoveMoney(upgradeCost);
                GameManager.instance.UpgradeHealth();
                upgradeCost *= 2;
                Debug.Log("upgrade is now " + upgradeCost);
                cost.text = "$" + upgradeCost;
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
