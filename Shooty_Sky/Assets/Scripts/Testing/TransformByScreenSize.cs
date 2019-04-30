using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TransformByScreenSize : MonoBehaviour
{
    public enum Side {Up, Down, Left, Right}

    public Side borderSide;
    public float thickness;
    
    // Start is called before the first frame update
    void Start()
    {
        var posX = (borderSide == Side.Up || borderSide == Side.Down)
            ? 0
            : (borderSide == Side.Left
                ? Camera.main.ScreenToWorldPoint(Vector2.zero).x - thickness / 2
                : Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x + thickness / 2);
        var posY = (borderSide == Side.Left || borderSide == Side.Right)
            ? 0
            : (borderSide == Side.Down
                ? Camera.main.ScreenToWorldPoint(Vector2.zero).y - thickness / 2
                : Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y + thickness / 2);
        transform.position = new Vector2(posX, posY);

        var scaleX = (borderSide == Side.Up || borderSide == Side.Down)
            ? Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x * 2f
            : thickness;
        var scaleY = (borderSide == Side.Left || borderSide == Side.Right)
            ? Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y * 2f
            : thickness;
        transform.localScale = new Vector2(scaleX, scaleY);
    }
}
