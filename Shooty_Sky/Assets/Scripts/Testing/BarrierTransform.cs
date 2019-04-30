using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BarrierTransform : MonoBehaviour
{
    public enum Side {Up, Down, Left, Right}

    public Side borderSide;
    public float thickness;
    
    // Start is called before the first frame update
    void Start()
    {
        var max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        var min = Camera.main.ScreenToWorldPoint(Vector2.zero);
        
        var posX = (borderSide == Side.Up || borderSide == Side.Down)
            ? 0
            : (borderSide == Side.Left
                ? min.x - thickness / 2
                : max.x + thickness / 2);
        var posY = (borderSide == Side.Left || borderSide == Side.Right)
            ? 0
            : (borderSide == Side.Down
                ? min.y - thickness / 2
                : max.y + thickness / 2);
        
        var transform1 = transform;
        transform1.position = new Vector2(posX, posY);

        var scaleX = (borderSide == Side.Up || borderSide == Side.Down)
            ? max.x * 2f
            : thickness;
        var scaleY = (borderSide == Side.Left || borderSide == Side.Right)
            ? max.y * 2f
            : thickness;
        
        transform1.localScale = new Vector2(scaleX, scaleY);
    }
}
