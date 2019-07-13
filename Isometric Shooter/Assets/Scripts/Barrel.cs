using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] AudioClip explosionClip;

    private AudioSource _barrelAudioSource;
    private ParticleSystem _explosionParticleSystem;
    private CapsuleCollider _capsuleCollider;
    private bool _isDead;

    private void Awake()
    {
        _barrelAudioSource = GetComponent<AudioSource>();
        _explosionParticleSystem = GetComponent<ParticleSystem>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    public void Death()
    {
        _isDead = true;
        _capsuleCollider.isTrigger = true;
        //_barrelAudioSource.clip = explosionClip;
        //_barrelAudioSource.Play();
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void Respawn()
    {

    }
}
