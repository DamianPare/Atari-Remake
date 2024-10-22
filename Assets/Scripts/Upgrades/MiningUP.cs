using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningUP : Shop
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7 && Input.GetKeyDown(KeyCode.Space))
        {
            if (money > upgradeCost)
            {
                GameManager.instance.RemoveMoney(upgradeCost);
                GameManager.instance.UpgradeMining();
                upgradeCost *= 2;
                Debug.Log("upgrade is now " + upgradeCost);
            }

            else
            {
                Debug.Log("Not Enough Money");
            }
        }
    }
}
