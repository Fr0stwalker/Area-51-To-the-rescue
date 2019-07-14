using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    Vector3 _playerPosition;
    float distanceFromEnemyToPlayer;
    [SerializeField] private float timeBetweenAttacks = 0.5f;
    private float _timer;
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        FindPlayerCharacter();
        DistanceToPlayer();
        if (_timer >= timeBetweenAttacks && distanceFromEnemyToPlayer <= 1)
        {
            AttackPlayer();
        }
    }


    private void FindPlayerCharacter() {
        GameObject isPlayerAlive = GameObject.Find("Player");
        if (isPlayerAlive) {
            _playerPosition = isPlayerAlive.transform.position;
        }
        else {
            return;
        }
    }
    private void DistanceToPlayer() {
        if (GameObject.Find("Player") != null)
        {
            distanceFromEnemyToPlayer = Vector3.Distance(
                GameObject.Find("Player").transform.position,
                transform.position
            );
        }
    }
    
     /* Stary skrypt poruszania się do gracza, zostawiłem go może na przyszłość, można usunąć jeśli przeszkadza
    
    private void MoveTowardsPlayerPosition() {
        float moveToPlayerSpeed = MovementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, moveToPlayerSpeed);
    } 
    
    */

    // TODO: Attack player, currently enemy dissapear in 1 radius
    private void AttackPlayer()
    {
        _timer = 0f;
        _anim.Play("Attacking",0,0);
        GameObject.Find("Player").GetComponent<PlayerHealth>().TakeDamage();
    }

}
