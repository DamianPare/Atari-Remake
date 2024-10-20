using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int miningLevel = 0;
    public int money;
    public int health = 100;
    public static GameManager instance;

    void Start()
    {
        instance = this;
    }

    public void AddMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        Debug.Log(money);
        Debug.Log(health);
    }

    public void RemoveMoney(int moneyToRemove)
    {
        money -= moneyToRemove;
        Debug.Log(money);
    }

    public void UpgradeMining()
    {
        miningLevel++;
    }

    public void RemoveHealth(int damage)
    {
        health -= damage;
    }
}

