using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    [SerializeField] private AudioSource damageSFX;

    public System.Action onDamageTaken; 

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (onDamageTaken != null)
            onDamageTaken.Invoke();

        if (currentHealth > 0)
        {
            //Player Hurt
        }
        else
        {
            //Player Dead
        }
    }

    private void Update()
    {
        // Testing HealthBar
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            damageSFX.Play();
            TakeDamage(1);
        }
    }
}
