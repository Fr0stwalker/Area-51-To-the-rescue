using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private int scorePerEnemy=50;
    private ScoreManagement _scoreManager;
    private AudioSource _audioSource;
    private float timer;
    private void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManagement>();
        _audioSource = FindObjectOfType<AudioSource>();

    }

    void OnDestroy()
    {
        _audioSource.Play();
        while (timer < 3.0f)
        {
            timer += Time.deltaTime;
        }
        _scoreManager.CurrentScore += scorePerEnemy;
    }
}
