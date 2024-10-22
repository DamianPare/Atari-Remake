using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private Sound blockDesSound;
    [SerializeField] private Sound blockRestSound;
    [SerializeField] private Sound throwPickaxe;
    [SerializeField] private Sound upgrade;
    [SerializeField] private Sound heal;
    [SerializeField] private Sound hurt;
    [SerializeField] private Sound enemyHit;
    [SerializeField] private Sound death;
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

    void OnBlockDestroyed ( ) 
    {
        blockDesSound.Source.Play();
    }
    void OnBlockRestricted()
    {
        blockRestSound.Source.Play();
    }

    void OnAttacking()
    {
        throwPickaxe.Source.Play();
    }

    void OnHeal()
    {
        musicSource.pitch = 1;
        heal.Source.Play();
    }

    void OnDamaged()
    {
        musicSource.pitch = musicSource.pitch - (Time.deltaTime * .01f);
    }

    void OnUpgrade() 
    {
        upgrade.Source.Play();
    }

    void OnHitEnemy()
    {
        enemyHit.Source.Play();
    }
}
