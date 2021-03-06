﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionWhileEntering : StateMachineBehaviour
{
    
    public Vector3 ratios;
    private StartingTargetPositionTracker _startTargetTracker;
    public float time;
    public AnimationCurve pos;

    private Vector3 _anchorPosition;
    private float _currentTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _startTargetTracker = animator.gameObject.GetComponent<StartingTargetPositionTracker>();
        _anchorPosition = _startTargetTracker.startingPos + new Vector2((_startTargetTracker.targetPos - _startTargetTracker.startingPos).x * ratios.x, (_startTargetTracker.targetPos - _startTargetTracker.startingPos).y * ratios.y);
        _currentTime = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_currentTime > time)
        {
            animator.SetBool("Entered", true);
        }

        animator.gameObject.transform.position = Vector3.Lerp(_startTargetTracker.startingPos, _anchorPosition,
            pos.Evaluate(_currentTime / time));

        _currentTime += Time.deltaTime;
    }
}
