using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip blockDesSound;
    [SerializeField] private AudioClip blockRestSound;
    [SerializeField] private Movement playerListener;


    private void Awake()
    {
        if (playerListener != null)
        {
            playerListener.blockDestroyed += OnBlockDestroyed;
            playerListener.blockRestricted += OnBlockRestricted;
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
}
