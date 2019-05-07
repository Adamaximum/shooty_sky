using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionByAnimationCurve : MonoBehaviour
{

    public float screenTime;

    public Vector2 startingPos;
    public Vector2 targetPos;

    public AnimationCurve posX;
    public AnimationCurve posY;

    private float _currentTime;
    
    // Start is called before the first frame update
    private void Start()
    {
        _currentTime = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_currentTime >= screenTime)
        {
            Destroy(gameObject);
        }

        var x = Mathf.Lerp(startingPos.x, targetPos.x, posX.Evaluate(_currentTime/screenTime));
        var y = Mathf.Lerp(startingPos.y, targetPos.y, this.posY.Evaluate(_currentTime/screenTime));
        transform.position = new Vector3(x, y);
        
        _currentTime += Time.deltaTime;
    }
}
