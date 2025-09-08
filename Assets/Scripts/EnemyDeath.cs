using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject deathVFX;   // Assign a particle prefab in Inspector
    public AudioClip deathSFX;    // Assign sound in Inspector

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.CompareTag("Bullet"))
        {
            // Detach the VFX from the enemy, activate, and let it play
            if (deathVFX != null)
            {
                deathVFX.transform.parent = null;      // unparent from enemy
                deathVFX.SetActive(true);              // make sure it’s visible
                Destroy(deathVFX, 3f);                 // destroy after duration
            }

            // Spawn temporary audio object
            if (deathSFX != null)
            {
                GameObject audioObj = new GameObject("TempAudio");
                AudioSource aSource = audioObj.AddComponent<AudioSource>();
                aSource.clip = deathSFX;
                aSource.Play();
                Destroy(audioObj, deathSFX.length); // clean up after SFX finished
            }

            Destroy(gameObject);
        }
    }
}
