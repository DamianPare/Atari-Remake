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
    [SerializeField] private Movement movementListener;


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
            movementListener.blockRestricted += OnBlockRestricted;
            movementListener.blockDestroyed += OnBlockDestroyed;
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
        hurt.Play();
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
