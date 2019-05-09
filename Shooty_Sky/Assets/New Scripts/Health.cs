using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public bool enemy;
    public float scoreOnKilled;
    
    public float maxHealth;

    public float currentHealth;

    public AudioSource audioSource;

    public GameMasterTracker tracker;
    
    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        audioSource.Play();

        currentHealth -= other.gameObject.GetComponent<DealDamageOnCollision>().damage;
        if (currentHealth <= 0)
        {
            if (enemy)
            {
                tracker.gameManager.score += scoreOnKilled;
            }
            Destroy(gameObject);
        }
    }
}
