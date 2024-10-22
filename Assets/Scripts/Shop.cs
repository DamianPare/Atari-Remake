using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] int upgradeCost;
    private int money;

    private void Update()
    {
        money = GameManager.instance.money;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            if (money > upgradeCost)
            {
                GameManager.instance.RemoveMoney(upgradeCost);
                GameManager.instance.UpgradeMining();
                upgradeCost *= 2;
                Debug.Log(upgradeCost);
            }

            else
            {
                Debug.Log("Not Enough Money");
            }
        }
    }
}
