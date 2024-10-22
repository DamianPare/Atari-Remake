using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int miningLevel = 0;
    public int money;
    public float maxHealth = 100f;
    private float health;
    public static GameManager instance;
    public Text moneyCounter;
    public Image healthBar;

    public event Action healPerformed;
    public event Action damageRecieved;
    public event Action upgradedLevel;

    void Start()
    {
        health = maxHealth;
        instance = this;
    }

    private void Update()
    {
        healthBar.fillAmount = health / maxHealth;

        if (health < 0)
        {
            GameOver();
        }
    }

    public void AddMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        moneyCounter.text = "$" + money;
    }

    public void RemoveMoney(int moneyToRemove)
    {
        money -= moneyToRemove;
        moneyCounter.text = "$" + money;
        Debug.Log(money);
    }

    public void UpgradeMining()
    {
        miningLevel++;
        upgradedLevel?.Invoke();
    }

    public void UpgradeHealth()
    {
        health *= 2;
        healPerformed?.Invoke();
    }

    public void RemoveHealth(float damage)
    {
        health -= damage * Time.deltaTime;
        damageRecieved?.Invoke();
    }

    public void RestoreHealth()
    {
        health = maxHealth;
        healPerformed?.Invoke();
    }

    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

