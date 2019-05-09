using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FireByInput : MonoBehaviour
{
    public GameObject p0P0;
    public GameObject p0P1;
    
    public float coolDownTime;

    private float _coolDownRemaining = 0;

    private Vector3 lastPosition;
    private Vector3 thisPosition;

    public AudioSource audioSource;

    private void Start()
    {
        thisPosition = transform.position;
    }

    // Start is called before the first frame update
    private void Update()
    {
        lastPosition = thisPosition;
        thisPosition = transform.position;
        
        if (Input.GetKey(KeyCode.LeftShift) && _coolDownRemaining <= 0)
        {
            var projectile = Instantiate(p0P1, transform.position, Quaternion.identity);
            projectile.GetComponent<PositionByConstantVelocity>().direction =
                (thisPosition - lastPosition == Vector3.zero)
                    ? Vector3.up
                    : (thisPosition - lastPosition).normalized;
            _coolDownRemaining = coolDownTime;
        }
        else if (Input.GetKey(KeyCode.Space) && _coolDownRemaining <= 0)
        {
            audioSource.Play();

            Instantiate(p0P0, transform.position, Quaternion.identity);
            _coolDownRemaining = coolDownTime;
        }
        else
        {
            _coolDownRemaining -= Time.deltaTime;
        }
    }
}
