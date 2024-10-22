using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip blockDesSound;
    [SerializeField] private AudioClip blockRestSound;
    [SerializeField] private AudioClip throwPickaxe;
    [SerializeField] private AudioClip upgrade;
    [SerializeField] private AudioClip heal;
    [SerializeField] private AudioClip hurt;
    [SerializeField] private AudioClip enemyHit;
    [SerializeField] private AudioClip death;
    [SerializeField] private Movement playerListener;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Attack attack;


    private void Awake()
    {
        if (playerListener != null)
        {
            playerListener.blockDestroyed += OnBlockDestroyed;
            playerListener.blockRestricted += OnBlockRestricted;
            playerListener.attackPerformed += OnAttacking;
            gameManager.healPerformed += OnHeal;
            gameManager.damageRecieved += OnDamaged;
            gameManager.upgradedLevel += OnUpgrade;
            attack.hitEnemy += OnHitEnemy;
        }
    }

    void OnBlockDestroyed ( ) 
    {
        AudioSource.PlayClipAtPoint(blockDesSound, transform.position, 1f);
    }
    void OnBlockRestricted()
    {
        AudioSource.PlayClipAtPoint(blockRestSound, transform.position, 1f);
    }

    void OnAttacking()
    {
        AudioSource.PlayClipAtPoint(throwPickaxe, transform.position, 1f);
    }

    void OnHeal()
    {
        musicSource.pitch = 1;
        AudioSource.PlayClipAtPoint(heal, transform.position, 1f);
    }

    void OnDamaged()
    {
        musicSource.pitch = musicSource.pitch - (Time.deltaTime * .01f);
    }

    void OnUpgrade() 
    {
        AudioSource.PlayClipAtPoint(upgrade, transform.position, 1f);
    }

    void OnHitEnemy()
    {
        AudioSource.PlayClipAtPoint(enemyHit, transform.position, 1f);
    }
}
