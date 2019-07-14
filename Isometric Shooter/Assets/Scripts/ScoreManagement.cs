using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{
    private Text _scoreText;
    private int _currentScore;

    private void Awake()
    {
        _scoreText = FindObjectOfType<Canvas>().gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).GetComponent<Text>();
    }

    public int CurrentScore
    {
        get => _currentScore;
        set
        {
            _currentScore = value;
            _scoreText.text = value.ToString();
        }
    }
}
