using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionByInput : MonoBehaviour
{
    public float speed;
    
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * speed * Time.deltaTime;
    }
}
