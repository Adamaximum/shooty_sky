using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ClampPositionOnScreen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        var posX = position.x;
        var posY = position.y;
        posX = Mathf.Clamp(posX, Camera.main.ScreenToWorldPoint(Vector2.zero).x,
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x);
        posY = Mathf.Clamp(posY, Camera.main.ScreenToWorldPoint(Vector2.zero).y,
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y);
        position = new Vector2(posX, posY);
        transform.position = position;
    }
}
