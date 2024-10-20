using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int miningLevel = 0;
    public int money;
    public static GameManager instance;

    void Start()
    {
        instance = this;
    }

    public void AddMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        Debug.Log(money);
    }

    public void RemoveMoney(int moneyToRemove)
    {
        money -= moneyToRemove;
        Debug.Log(money);
    }

    public void Upgrade()
    {
        miningLevel++;
    }
}

