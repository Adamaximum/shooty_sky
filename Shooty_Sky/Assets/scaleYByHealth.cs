using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleYByHealth : MonoBehaviour
{

    public Health health;

    // Update is called once per frame
    private void Update()
    {
        transform.localScale = new Vector3(.1f, (health.currentHealth / health.maxHealth), 1);
    }
}
