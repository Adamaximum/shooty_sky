using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionByAnimationCurve : MonoBehaviour
{

    public float screenTime;

    public bool vertical;

    public Vector2 startingPos;
    public Vector2 targetPos;

    public AnimationCurve posX;
    public AnimationCurve posY;
    public AnimationCurve posDeviant;

    public float swayAmp;

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

        var x = vertical && Math.Abs(startingPos.x - targetPos.x) > 0.00001
            ? Mathf.Lerp(startingPos.x, targetPos.x, posDeviant.Evaluate(_currentTime / screenTime))
            : vertical
                ? Mathf.Lerp(startingPos.x - swayAmp, startingPos.x + swayAmp, posX.Evaluate(_currentTime / screenTime))
                : Mathf.Lerp(startingPos.x, targetPos.x, posX.Evaluate(_currentTime / screenTime));
        
        
        var y = !vertical && Math.Abs(startingPos.y - targetPos.y) > 0.00001
            ? Mathf.Lerp(startingPos.y, targetPos.y, posDeviant.Evaluate(_currentTime/screenTime))
            : !vertical
                ? Mathf.Lerp(startingPos.y - swayAmp, startingPos.y + swayAmp, posY.Evaluate(_currentTime/screenTime))
                : Mathf.Lerp(startingPos.y, targetPos.y, posY.Evaluate(_currentTime/screenTime));
        
        transform.position = new Vector3(x, y);
        
        _currentTime += Time.deltaTime;
    }
}
