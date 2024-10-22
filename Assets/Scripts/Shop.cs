using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public int upgradeCost;
    public int money;

    private void Update()
    {
        money = GameManager.instance.money;
    }
}
