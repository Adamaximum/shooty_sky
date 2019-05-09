using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionByAnimationCurve : MonoBehaviour
{

    public float screenTime;

    public bool vertical;

    public StartingTargetPositionTracker startTargetTracker;

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

        var x = vertical && Math.Abs(startTargetTracker.startingPos.x - startTargetTracker.targetPos.x) > 0.00001
            ? Mathf.Lerp(startTargetTracker.startingPos.x, startTargetTracker.targetPos.x, posDeviant.Evaluate(_currentTime / screenTime))
            : vertical
                ? Mathf.Lerp(startTargetTracker.startingPos.x - swayAmp, startTargetTracker.startingPos.x + swayAmp, posX.Evaluate(_currentTime / screenTime))
                : Mathf.Lerp(startTargetTracker.startingPos.x, startTargetTracker.targetPos.x, posX.Evaluate(_currentTime / screenTime));
        
        
        var y = !vertical && Math.Abs(startTargetTracker.startingPos.y - startTargetTracker.targetPos.y) > 0.00001
            ? Mathf.Lerp(startTargetTracker.startingPos.y, startTargetTracker.targetPos.y, posDeviant.Evaluate(_currentTime/screenTime))
            : !vertical
                ? Mathf.Lerp(startTargetTracker.startingPos.y - swayAmp, startTargetTracker.startingPos.y + swayAmp, posY.Evaluate(_currentTime/screenTime))
                : Mathf.Lerp(startTargetTracker.startingPos.y, startTargetTracker.targetPos.y, posY.Evaluate(_currentTime/screenTime));
        
        transform.position = new Vector3(x, y);
        
        _currentTime += Time.deltaTime;
    }
}
