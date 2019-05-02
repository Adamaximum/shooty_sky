using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FireByInput : MonoBehaviour
{
    public GameObject bullet;
    public float coolDownTime;

    private float _coolDownRemaining = 0;

    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _coolDownRemaining <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            _coolDownRemaining = coolDownTime;
        }
        else if (_coolDownRemaining > 0)
        {
            _coolDownRemaining -= Time.deltaTime;
        }
    }
    
}
