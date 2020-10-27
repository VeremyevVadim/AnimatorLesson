using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private Animator _animator = default;

    private int _jump = 0;
    private int _rotate = 0;
    private int _scale = 0;
    private int _color = 0;
    private int _clickTrigger = -1;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _jump = Animator.StringToHash("Jump");
        _rotate = Animator.StringToHash("Rotation");
        _scale = Animator.StringToHash("Scale");
        _color = Animator.StringToHash("Color");
        _clickTrigger = Animator.StringToHash("Click");
    }

    public void OnClick()
    {
        _animator.SetFloat(_color, Random.Range(0f, 1f));
        _animator.SetFloat(_rotate, Random.Range(0f, 1f));
        _animator.SetFloat(_scale, Random.Range(0f, 1f));
        _animator.SetFloat(_jump, Random.Range(0f, 1f));
        _animator.SetTrigger(_clickTrigger);
    }
}
