﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionByConstantVelocity: MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    private void FixedUpdate()
    {
        transform.position += direction.normalized * (speed * Time.deltaTime);
    }
}
