using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private IEnumerator _coroutine;
    private ParticleSystem _explosionParticleSystem;
    private void Awake()
    {
        _explosionParticleSystem = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        Debug.Log("Boom");
        print("Starting " + Time.time + " seconds");
        _coroutine = Explosion(0.5f);
        StartCoroutine(_coroutine);
    }


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Was in Explosion when it started");
        Destroy(other.gameObject);
    }
    private IEnumerator Explosion(float time)
    {
        Debug.Log("Explosion started");
        _explosionParticleSystem.Play();
        yield return new WaitForSeconds(time);
        Debug.Log("Explosion ended");
        print("Coroutine ended: " + Time.time + " seconds");
        gameObject.SetActive(false);
    }
}
