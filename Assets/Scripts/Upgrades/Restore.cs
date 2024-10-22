using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restore : Shop
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7 && Input.GetKeyDown(KeyCode.Space))
        {
            if (money > upgradeCost)
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
}
