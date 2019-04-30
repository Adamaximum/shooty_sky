using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementByInput : Movement
{
    // Start is called before the first frame update
    void Update()
    {
        transform.position += InputMovement();
    }
    
    private Vector3 InputMovement()
    {
        return new Vector2(Input.GetAxis("Horizontal") * maxSpeed, Input.GetAxis("Vertical") * maxSpeed);
    }
}
