using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionWhileFiring : StateMachineBehaviour
{
    public AnimationCurve posXLoop;
    public AnimationCurve posYLoop;
    public Vector2 swayAmp;
    public float loopTime;

    
    public Vector3 ratios;
    public StartingTargetPositionTracker startTargetTracker;
    private Vector3 _anchorPosition;
    
    private float _currentTime; 
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _anchorPosition = new Vector3((startTargetTracker.targetPos - startTargetTracker.targetPos).x * ratios.x, (startTargetTracker.targetPos - startTargetTracker.targetPos).y * ratios.y);
        _currentTime = 0;
    }
    
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var x = Mathf.Lerp(-swayAmp.x, swayAmp.x, posXLoop.Evaluate((_currentTime % loopTime) / loopTime));
        var y = Mathf.Lerp(-swayAmp.y, swayAmp.y, posYLoop.Evaluate((_currentTime % loopTime) / loopTime));
        var deviationFromAnchor = new Vector3(x,y);
        animator.gameObject.transform.position = _anchorPosition + deviationFromAnchor;
    }
}
