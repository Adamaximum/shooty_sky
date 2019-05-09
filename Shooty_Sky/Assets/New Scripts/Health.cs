using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    public float maxHealth;

    private float _currentHealth;

    public AudioSource audioSource;
    
    // Start is called before the first frame update
    private void Start()
    {
        _currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        audioSource.Play();

        _currentHealth -= other.gameObject.GetComponent<DealDamageOnCollision>().damage;
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
