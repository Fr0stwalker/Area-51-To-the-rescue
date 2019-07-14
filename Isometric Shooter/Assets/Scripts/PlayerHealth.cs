using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject healthUi;
    [SerializeField] public int lives = 3;
    [SerializeField] private float invincibleTime = 3f;
    [SerializeField] public int currentLives;

    [SerializeField] private GameObject[] objectsToFlash;

    private Animator _animator;
    private AudioSource _playerAudioSource;

    //private bool _isDead;
    private bool _damaged;
    private bool _invincible;
    private float _timer;
    private int _heartToRemove=0;


    void Start() {

    }

    private void Update()
    {
        if (_damaged) {
            Debug.Log("Ouch");
            _invincible = true;
            TriggerInvincibleFlashing();
            Debug.Log("Can't hit me");
        }

        if (_invincible)
        {
            _timer += Time.deltaTime;
        }

        if (_timer >= invincibleTime)
        {
            Debug.Log("Can hit me");
            _timer = 0f;
            _invincible = false;
            _damaged = false;
            TriggerInvincibleFlashing();
        }
    }

    private void TriggerInvincibleFlashing() {
        foreach (GameObject playerElements in objectsToFlash) {
            var meshTrigger = playerElements.GetComponent<Renderer>();
            if (_invincible == true) {
                CharacterFlash(meshTrigger);
            }
            else if (_invincible == false) {
                meshTrigger.enabled = true;
            }
        }
    }

    private static void CharacterFlash(Renderer meshTrigger) {
        if (Time.time % 0.5 < 0.2) {
            meshTrigger.enabled = false;
        }
        else {
            meshTrigger.enabled = true;
        }
    }

    public void TakeDamage()
    {
        if (!_invincible)
        {
            _damaged = true;
            currentLives--;
            healthUi.transform.GetChild(_heartToRemove).gameObject.SetActive(false);
            _heartToRemove++;

        }
        if (currentLives <=0)
        {
            gameObject.SetActive(false);
        }

    }

    void OnDestroy()
    {
        healthUi.transform.GetChild(0).gameObject.SetActive(false);
        healthUi.transform.GetChild(1).gameObject.SetActive(false);
        healthUi.transform.GetChild(2).gameObject.SetActive(false);
        FindObjectOfType<GameOver>().GameOverPanel();
        Time.timeScale = 0;
        Debug.Log("I died");
    }
}
