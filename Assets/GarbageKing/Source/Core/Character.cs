using PixupGames.Infrastracture.Services;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement), typeof(CharacterAnimation))]
public class Character : MonoBehaviour, ICharacter, IControlledCharacter
{
    [SerializeField] private CharacterMovement _movement;
    [SerializeField] private CharacterAnimation _animation;

    private void Update()
    {
        _animation.PlayMovement(_movement.Velocity);
    }

    public void Move(Vector3 direction)
    {
        _movement.Move(direction);
    }
}
