using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPosition += InputMovement();
    }

    protected Vector3 InputMovement()
    {
        var deltaPosition = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            deltaPosition += new Vector3(0, maxSpeed, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            deltaPosition += new Vector3(-maxSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            deltaPosition += new Vector3(0, -maxSpeed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            deltaPosition += new Vector3(maxSpeed, 0, 0);
        }

        return deltaPosition;
    }
}
