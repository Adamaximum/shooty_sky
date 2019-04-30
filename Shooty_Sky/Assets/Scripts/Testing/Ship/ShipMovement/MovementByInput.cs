using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementByInput : MonoBehaviour
{
    public float maxSpeedX;
    public float maxSpeedY;
    
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        transform.position += InputMovement();
    }
    
    private Vector3 InputMovement()
    {
        return new Vector2(Input.GetAxis("Horizontal") * maxSpeedX, Input.GetAxis("Vertical") * maxSpeedY);
    }
}
