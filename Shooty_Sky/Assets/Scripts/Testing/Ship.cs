using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    public float maxSpeed;
    public float maxHealth;


    protected Vector3 CurrentPosition
    {
        get => transform.position;
        set => transform.position = value;
    }
    
    
}
