using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour
{
    private ScoreManagement _scoreManager;
    private void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManagement>();
    }

    void OnDestroy()
    {
        _scoreManager.CurrentScore += 50;
    }
}
