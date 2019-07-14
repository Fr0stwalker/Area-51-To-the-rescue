using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private IEnumerator _coroutine;
    //private ParticleSystem _explosionParticleSystem;


    [SerializeField] private ParticleSystem deathFX;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private float corpseDespawn=3.0f;
    [SerializeField] private GameObject audio;

    private bool playOnce=true;


    private void OnEnable()
    {
        Debug.Log("Boom");
        playOnce = true;
        print("Starting " + Time.time + " seconds");
        _coroutine = Explosion(0.5f);
        StartCoroutine(_coroutine);
    }


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Was in Explosion when it started");
        if (playOnce && other.gameObject.CompareTag("Enemy"))
        {
            playOnce = false;
            audio.GetComponent<AudioSource>().Play();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            var go =Instantiate(deathEffect, other.gameObject.transform.position, Quaternion.identity);
            Destroy(go, corpseDespawn);
        }

        Destroy(other.gameObject);
        
    }
    private IEnumerator Explosion(float time)
    {
        deathFX.Play();
        Debug.Log("Explosion started");
        //_explosionParticleSystem.Play();
        yield return new WaitForSeconds(time);
        Debug.Log("Explosion ended");
        print("Coroutine ended: " + Time.time + " seconds");
        gameObject.SetActive(false);
    }
}
