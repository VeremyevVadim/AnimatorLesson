using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterController : MonoBehaviour
{
    private Animator _animator = default;

    private int _jumpTrigger = -1;
    private int _walkSpeed = -1;
    private int _crouch = -1;

    private Transform _transform;

    private Vector3 _leftScale;
    private Vector3 _rightScale;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _crouch = Animator.StringToHash("IsCrouch");
        _walkSpeed = Animator.StringToHash("WalkSpeed");
        _jumpTrigger = Animator.StringToHash("Jump");

        _transform = transform;
        
        var localScale = _transform.localScale;
        _leftScale = localScale;
        _leftScale.x = -_leftScale.x;
        
        _rightScale = localScale;
    }

    
    // A/D - movement, Space - jump, C - crouch
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(_jumpTrigger);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _animator.SetInteger(_walkSpeed, 1);
            _transform.localScale = _leftScale;         // Turn character in walk direction
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _animator.SetInteger(_walkSpeed, 1);
            _transform.localScale = _rightScale;         // Turn character in walk direction
        }
        else
        {
            _animator.SetInteger(_walkSpeed, 0);
        }

        _animator.SetBool(_crouch, Input.GetKey(KeyCode.C));
    }
}
