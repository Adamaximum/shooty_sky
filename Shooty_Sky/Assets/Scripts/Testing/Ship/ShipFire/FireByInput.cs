using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireByInput : MonoBehaviour
{
    public GameObject bullet;
    
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
    
}
