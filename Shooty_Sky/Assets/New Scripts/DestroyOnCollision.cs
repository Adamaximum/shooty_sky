using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public bool player;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
