using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class RunBehavior : StateMachineBehaviour
{
    private float _baseAnimSpeed = 1;
    private float _deltaTime = 0f;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _baseAnimSpeed = animator.speed;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _deltaTime += Time.deltaTime;
        if (_deltaTime > 1f)
        {
            animator.speed = _baseAnimSpeed / 2f;
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.speed = _baseAnimSpeed;
        _deltaTime = 0f;
    }
}
