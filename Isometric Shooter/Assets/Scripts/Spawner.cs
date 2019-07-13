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
        Instantiate(enemy,gameObject.transform.position,Quaternion.identity);
    }
}
