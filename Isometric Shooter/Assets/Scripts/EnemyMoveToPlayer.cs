using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveToPlayer : MonoBehaviour
{
    void Start()
    {
    }

    // Update is called once per frame
    void Update() {
        GameObject findPlayer = GameObject.FindGameObjectWithTag("Player");
        var moveToPlayer = findPlayer.transform.position;
        NavMeshAgent enemyNavMoveTowardPlayer = GetComponent<NavMeshAgent>();
        enemyNavMoveTowardPlayer.destination = moveToPlayer;

    }
}
