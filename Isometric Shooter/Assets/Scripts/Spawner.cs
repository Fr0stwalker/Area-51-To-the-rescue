using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnTimer=10f;
    [SerializeField] private float firstSpawnTimerDelay = 5f;
    [SerializeField] private GameObject enemy;
    private float timer;
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        timer = spawnTimer- firstSpawnTimerDelay;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTimer)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        timer = 0f;
        _particleSystem.Play();
        Instantiate(enemy,gameObject.transform.position,Quaternion.identity);
    }
}
