using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var xPos = transform.position.x;
        xPos += speed * Time.deltaTime;
        if (xPos > Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x + 0.5f)
        {
            xPos = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x - 0.5f;
        }
        transform.position = new Vector2(xPos, transform.position.y);
    }
}
