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
        transform.position += new Vector3(Input.GetAxis("Horizontal") * (maxSpeedX * Time.deltaTime), Input.GetAxis("Vertical") * (maxSpeedY * Time.deltaTime));
    }
}
