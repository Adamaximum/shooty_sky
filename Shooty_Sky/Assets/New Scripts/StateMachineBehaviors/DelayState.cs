using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayState : StateMachineBehaviour
{
    public float delayTime;

    private float _currentTime;
    private static readonly int Delayed = Animator.StringToHash("Delayed");

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _currentTime = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= delayTime)
        {
            animator.SetBool(Delayed, true);
        }
    }
}
