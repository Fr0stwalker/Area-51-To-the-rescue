using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int lives = 3;

    [SerializeField] private int currentLives;
    [SerializeField] private AudioClip deathClip;

    private Animator _animator;
    private AudioSource _playerAudioSource;

    //private bool _isDead;
    private bool _damaged;
}
