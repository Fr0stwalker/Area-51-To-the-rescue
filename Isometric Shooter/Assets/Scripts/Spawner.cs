using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnTimer=10f;
    [SerializeField] private GameObject enemy;
    private float timer;

    private void Start()
    {
        timer = spawnTimer;
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
