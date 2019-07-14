using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private int scorePerEnemy=50;
    [SerializeField] private GameObject deathEffect;
    private ScoreManagement _scoreManager;
    private AudioSource _audioSource;
    private float timer=0f;
    private void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManagement>();
        _audioSource = FindObjectOfType<AudioSource>();

    }

    void OnDestroy()
    {
        
        _scoreManager.CurrentScore += scorePerEnemy;
    }
}
