using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    public float maxHealth;

    private float _currentHealth;
    
    // Start is called before the first frame update
    private void Start()
    {
        _currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("called on " + gameObject.name);
        _currentHealth -= other.gameObject.GetComponent<DealDamageOnCollision>().damage;
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
