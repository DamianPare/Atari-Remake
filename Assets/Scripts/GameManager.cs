using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int miningLevel = 0;
    public int money;
    public int maxHealth = 100;
    private int health;
    public static GameManager instance;

    void Start()
    {
        health = maxHealth;
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

    public void UpgradeHealth()
    {
        health *= 2;
    }

    public void RemoveHealth(int damage)
    {
        health -= damage;
    }

    public void RestoreHealth()
    {
        health = maxHealth;
    }
}

