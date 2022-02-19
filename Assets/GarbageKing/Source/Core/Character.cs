using PixupGames.Infrastracture.Services;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class Character : MonoBehaviour, ICharacter
{
    [SerializeField] private CharacterMovement _movement;
    [SerializeField] private CharacterAnimation _animation;

    private IGameSaves<PlayerProgress> _saves;

    public void Init(IGameSaves<PlayerProgress> saves)
    {
        _saves = saves;
    }

    private void Update()
    {
        _animation.PlayMovement(_movement.Velocity);
    }

    public void Move(Vector3 direction)
    {
        _movement.Move(direction);
    }
}
