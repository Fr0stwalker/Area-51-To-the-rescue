using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int lives = 3;
    [SerializeField] private float invincibleTime = 3f;
    [SerializeField] public int currentLives;
    [SerializeField] private AudioClip deathClip;

    private Animator _animator;
    private AudioSource _playerAudioSource;

    //private bool _isDead;
    private bool _damaged;
    private bool _invincible;
    private float timer;

    private void Update()
    {
        if (_damaged)
        {
            Debug.Log("Ouch");
            _invincible = true;
            Debug.Log("Can't hit me");
        }

        if (_invincible)
        {
            timer += Time.deltaTime;
        }

        if (timer >= invincibleTime)
        {
            Debug.Log("Can hit me");
            timer = 0f;
            _invincible = false;
            _damaged = false;
        }
    }

    public void TakeDamage()
    {
        if (!_invincible)
        {
            _damaged = true;
            currentLives--;
        }
        if (currentLives <=0)
        {
            gameObject.SetActive(false);
        }

    }

    void OnDestroy()
    {
        Debug.Log("I died");
    }
}
