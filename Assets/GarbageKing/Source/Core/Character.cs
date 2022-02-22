using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement), typeof(CharacterAnimation))]
public class Character : MonoBehaviour, ICharacter
{
    [SerializeField] private CharacterMovement _movement;
    [SerializeField] private CharacterAnimation _animation;
    [SerializeField] private GarbageCollector _garbageCollector;

    public bool Alive => true;

    private void Update()
    {
        _animation.PlayMovement(_movement.Velocity);
    }

    public void Move(Vector3 direction)
    {
        _movement.Move(direction);
    }
}
