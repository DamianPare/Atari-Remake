using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource blockDesSound;
    [SerializeField] private AudioSource blockRestSound;
    [SerializeField] private AudioSource throwPickaxe;
    [SerializeField] private AudioSource upgrade;
    [SerializeField] private AudioSource heal;
    [SerializeField] private AudioSource hurt;
    [SerializeField] private AudioSource enemyHit;
    [SerializeField] private AudioSource death;
    [SerializeField] private GameManager gameManagerListener;
    [SerializeField] private Attack attackListener;


    private void Awake()
    {
        if (attackListener != null)
        {
            attackListener.blockDestroyed += OnBlockDestroyed;
            attackListener.blockRestricted += OnBlockRestricted;
            attackListener.attackPerformed += OnAttacking;
            gameManagerListener.healPerformed += OnHeal;
            gameManagerListener.damageRecieved += OnDamaged;
            gameManagerListener.upgradedLevel += OnUpgrade;
            attackListener.hitEnemy += OnHitEnemy;
        }
    }

    void OnBlockDestroyed() 
    {
        blockDesSound.Play();
    }
    void OnBlockRestricted()
    {
        blockRestSound.Play();
    }

    void OnAttacking()
    {
        throwPickaxe.Play();
    }

    void OnHeal()
    {
        music.pitch = 1;
        heal.Play();
    }

    void OnDamaged()
    {
        music.pitch = music.pitch - (Time.deltaTime * .01f);
    }

    void OnUpgrade() 
    {
        upgrade.Play();
    }

    void OnHitEnemy()
    {
        enemyHit.Play();
    }
}
