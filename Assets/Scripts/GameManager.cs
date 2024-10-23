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
    public GameObject pickaxeHead;
    public GameObject helmet;

    public event Action healPerformed;
    public event Action damageRecieved;
    public event Action upgradedLevel;

    private SpriteRenderer pick;
    private SpriteRenderer hat;

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
        pick = pickaxeHead.GetComponent<SpriteRenderer>();

        if (miningLevel == 1)
        {
            pick.color = Color.yellow;
        }
        
        else if (miningLevel == 2)
        {
            pick.color = Color.cyan;
        }

        else if (miningLevel == 3)
        {
            pick.color = Color.red;
        }

        else if (miningLevel == 4)
        {
            pick.color = Color.magenta;
        }

        upgradedLevel?.Invoke();
    }

    public void UpgradeHealth()
    {
        maxHealth *= 2;
        health = maxHealth;
        hat = helmet.GetComponent<SpriteRenderer>();

        if (maxHealth == 200)
        {
            hat.color = Color.yellow;
        }

        else if (maxHealth == 400)
        {
            hat.color = Color.cyan;
        }

        else if (maxHealth == 800)
        {
            hat.color = Color.red;
        }

        else if (maxHealth == 1600)
        {
            hat.color = Color.magenta;
        }
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

