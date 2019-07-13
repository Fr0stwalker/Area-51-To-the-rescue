using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    Vector3 playerPosition;
    float distanceFromEnemyToPlayer;
    void Start() {

    }

    void Update() {
        FindPlayerCharacter();
        DistanceToPlayer();
        AttackPlayer();
    }


    private void FindPlayerCharacter() {
        GameObject isPlayerAlive = GameObject.Find("Player");
        if (isPlayerAlive) {
            playerPosition = isPlayerAlive.transform.position;
        }
        else {
            return;
        }
    }
    private void DistanceToPlayer() {
        distanceFromEnemyToPlayer = Vector3.Distance(
            GameObject.Find("Player").transform.position,
            transform.position
            );
    }
    
     /* Stary skrypt poruszania się do gracza, zostawiłem go może na przyszłość, można usunąć jeśli przeszkadza
    
    private void MoveTowardsPlayerPosition() {
        float moveToPlayerSpeed = MovementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, moveToPlayerSpeed);
    } 
    
    */

    // TODO: Attack player, currently enemy dissapear in 1 radius
    private void AttackPlayer() {
        if(distanceFromEnemyToPlayer <= 1) {
            Destroy(gameObject);
        }
    }

}
