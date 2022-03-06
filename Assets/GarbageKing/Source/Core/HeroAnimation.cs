using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HeroAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string Movement = nameof(Movement);

    public void PlayMovement(float velocity)
    {
        _animator.SetFloat(Movement, velocity);
    }
}
