using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private int scorePerEnemy=50;
    private ScoreManagement _scoreManager;
    private void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManagement>();
    }

    void OnDestroy()
    {
        _scoreManager.CurrentScore += scorePerEnemy;
    }
}
