using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Barrel : MonoBehaviour
{
    [SerializeField] AudioClip explosionClip;
    [SerializeField] private float respawnTimer=60f;
    //[SerializeField] private float explosionRadius = 0.4f;
    private NavMeshObstacle _barrelObstacle;
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
        _barrelObstacle = GetComponent<NavMeshObstacle>();
    }

    private void Update()
    {
        if (_isDead)
        {
            _respawnTimer += Time.deltaTime;
        }

        if (respawnTimer <= _respawnTimer)
        {
            Respawn();
        }
    }

    public void Death()
    {
        _isDead = true;
        _capsuleCollider.enabled = false;
        _barrelObstacle.enabled = false;
        _barrelAudioSource.Play();
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

    private void Respawn()
    {
        _capsuleCollider.enabled = true;
        _barrelObstacle.enabled = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        _isDead = false;
        _respawnTimer = 0f;
    }
}
