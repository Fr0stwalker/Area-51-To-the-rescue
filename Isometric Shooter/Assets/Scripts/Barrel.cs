using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] AudioClip explosionClip;
    [SerializeField] private float respawnTimer=60f;
    private AudioSource _barrelAudioSource;
    private ParticleSystem _explosionParticleSystem;
    private CapsuleCollider _capsuleCollider;
    private bool _isDead;
    private float _respawnTimer;
    

    private void Awake()
    {
        _barrelAudioSource = GetComponent<AudioSource>();
        _explosionParticleSystem = GetComponent<ParticleSystem>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        if (_isDead)
        {
            _respawnTimer += Time.deltaTime;
            //Debug.Log(_respawnTimer);
        }

        if (respawnTimer <= _respawnTimer)
        {
            Respawn();
        }
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
        Debug.Log("Respawn");
        _capsuleCollider.isTrigger = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        _isDead = false;
        _respawnTimer = 0f;
    }
}
