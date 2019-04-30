using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ClampPositionOnScreen : MonoBehaviour
{
    public Vector2 size;
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        var position = transform.position;
        var posX = position.x;
        var posY = position.y;
        posX = Mathf.Clamp(posX, Camera.main.ScreenToWorldPoint(Vector2.zero).x + size.x / 2,
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x - size.x / 2);
        posY = Mathf.Clamp(posY, Camera.main.ScreenToWorldPoint(Vector2.zero).y + size.y / 2,
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y - size.y / 2);
        position = new Vector2(posX, posY);
        transform.position = position;
    }
}
