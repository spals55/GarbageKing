using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HeroAnimation : MonoBehaviour, IHeroAnimation
{
    private const string Speed = nameof(Speed);

    [SerializeField] private Animator _animator;
    [SerializeField] private HandStack _handStack;

    private void OnEnable()
    {
        _handStack.Changed += OnHandStackChanged;
    }

    private void OnDisable()
    {
        _handStack.Changed -= OnHandStackChanged;
    }

    private void OnHandStackChanged()
    {
        if (_handStack.IsEmpty)
            _animator.SetLayerWeight(1, 0);
        else
            _animator.SetLayerWeight(1, 1f);
    }

    public void PlayMovement(float velocity)
    {
        _animator.SetFloat(Speed, velocity);
    }
}
