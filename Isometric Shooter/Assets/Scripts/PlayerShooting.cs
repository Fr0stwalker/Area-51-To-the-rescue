using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float timeBetweenBullets = 0.15f;

    [SerializeField] private float range = 50f;

    private float _timer;
    private Ray _shootRay;
    private RaycastHit _shootHit;
    private int _shootableMask;
    private ParticleSystem _gunParticleSystem;
    private LineRenderer _gunLineRenderer;
    private AudioSource _gunAudioSource;
    private Light _gunLight;
    private float _effectsDisplayTime=0.2f;

    void Awake()
    {
        _shootableMask = LayerMask.GetMask("Shootable");

        _gunParticleSystem = GetComponent<ParticleSystem>();
        _gunLineRenderer = GetComponent<LineRenderer>();
        _gunAudioSource = GetComponent<AudioSource>();
        _gunLight = GetComponent<Light>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= timeBetweenBullets * _effectsDisplayTime)
        {
            DisableEffects();
        }
    }

    private void DisableEffects()
    {
        _gunLineRenderer.enabled = false;
        _gunLight.enabled = false;
    }

    private void Shoot()
    {

    }
}
