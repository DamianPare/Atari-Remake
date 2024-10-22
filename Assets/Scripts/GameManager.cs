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

    public void RemoveHealth(float damage)
    {
        health -= damage * Time.deltaTime;
    }

    public void RestoreHealth()
    {
        health = maxHealth;
    }

    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

