using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GunController : MonoBehaviour
{
    [SerializeField] private AnimationClip _newAimAnimation;

    private Animator _animator;
    private AnimatorOverrideController _newOverrideController;
    private AnimatorOverrideController _baseOverrideController;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _baseOverrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);
    }

    private void Update()
    {
        if (_newAimAnimation && Input.GetKeyDown(KeyCode.Mouse1))
        {
            _newOverrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);
            _newOverrideController["Aim"] = _newAimAnimation;
            _animator.runtimeAnimatorController = _newOverrideController;
        }

        if (_newAimAnimation && Input.GetKeyUp(KeyCode.Mouse1))
        {
            _animator.runtimeAnimatorController = _baseOverrideController;
        }
    }
} 
