using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 5f;

    Vector3 playerPosition;
    float distanceFromEnemyToPlayer;
    void Start() {

    }

    void Update() {
        FindPlayerCharacter();
        DistanceToPlayer();
        MoveTowardsPlayerPosition();
        AttackPlayer();
    }


    private void FindPlayerCharacter() {
        GameObject isPlayerAlive = GameObject.Find("Player");
        if (isPlayerAlive) {
            playerPosition = isPlayerAlive.transform.position;
        }
    }
    private void DistanceToPlayer() {
        distanceFromEnemyToPlayer = Vector3.Distance(
            GameObject.FindGameObjectWithTag("Player").transform.position,
            transform.position
            );
    }
    private void MoveTowardsPlayerPosition() {
        float moveToPlayerSpeed = MovementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, moveToPlayerSpeed);
    }

    // TODO: Attack player, currently enemy dissapear in 1 radius
    private void AttackPlayer() {
        if(distanceFromEnemyToPlayer <= 1) {
            Destroy(gameObject);
        }
    }

}
