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
    private Animator _anim;
    private float _effectsDisplayTime=0.2f;

    void Awake()
    {
        _shootableMask = LayerMask.GetMask("Shootable");

        _gunParticleSystem = GetComponent<ParticleSystem>();
        _gunLineRenderer = GetComponent<LineRenderer>();
        _gunAudioSource = GetComponent<AudioSource>();
        _gunLight = GetComponent<Light>();
        _anim = transform.parent.gameObject.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && _timer >= timeBetweenBullets)
        {
            Shoot();
        }
        if (_timer >= timeBetweenBullets * _effectsDisplayTime)
        {
            DisableEffects();
        }
    }

    private void DisableEffects()
    {
        _gunLineRenderer.enabled = false;
        _gunLight.enabled = false;
        _gunParticleSystem.Stop();
    }

    private void Shoot()
    {
        _anim.Play("Shooting",0,0);
        // Reset the timer.
        _timer = 0f;
        // Play the gun shot audioclip.
        _gunAudioSource.Play();
        // Enable the light.
        _gunLight.enabled = true;
        // Stop the particles from playing if they were, then start the particles.
        //_gunParticleSystem.Stop();
        _gunParticleSystem.Play();
        // Enable the line renderer and set it's first position to be the end of the gun.
        //_gunLineRenderer.enabled = true;
        _gunLineRenderer.SetPosition(0,transform.position);
        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        _shootRay.origin = transform.position;
        _shootRay.direction = transform.forward;
        if (Physics.Raycast(_shootRay, out _shootHit, range, _shootableMask))
        {
            // Try and find an EnemyHealth script on the gameobject hit.
            Barrel barrel = _shootHit.collider.GetComponent<Barrel>();
            if (barrel != null)
            {
                barrel.Death();
            }
            
            //EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            // If the EnemyHealth component exist...
            //if (enemyHealth != null)
            //{
            // ... the enemy should take damage.
            //  enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            //}

            // Set the second position of the line renderer to the point the raycast hit.
            _gunLineRenderer.SetPosition(1, _shootHit.point);
            Debug.Log("Shot Barrel");
        }
        // If the raycast didn't hit anything on the shootable layer...
        else
        {
            // ... set the second position of the line renderer to the fullest extent of the gun's range.
            _gunLineRenderer.SetPosition(1, _shootRay.origin + _shootRay.direction * range);
        }
        
    }
}
