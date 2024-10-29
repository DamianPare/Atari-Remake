using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableBase : MonoBehaviour
{
    [SerializeField] private ParticleSystem destroyParticle;

    public void PlayParticles()
    {
        //destroyParticle.transform.position = position;
        destroyParticle.Play();
    }
}
