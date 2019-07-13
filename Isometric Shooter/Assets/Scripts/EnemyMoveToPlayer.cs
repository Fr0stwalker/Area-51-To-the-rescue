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
        var goTo = findPlayer.transform.position;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goTo;

    }
}
