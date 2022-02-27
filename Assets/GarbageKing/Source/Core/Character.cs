﻿using PixupGames.Infrastracture.Services;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement), typeof(CharacterAnimation))]
public class Character : MonoBehaviour, ICharacter
{
    [SerializeField] private CharacterMovement _movement;
    [SerializeField] private CharacterAnimation _animation;
    [SerializeField] private CharacterResourcesStack _resourcesStack;
    [SerializeField] private GarbageCollector _garbageCollector;

    public IMovement Movement => _movement;
    public IGarbageBag Bag => _garbageCollector.Bag;


    private void Update()
    {
        _animation.PlayMovement(_movement.Velocity);
    }

    public void Move(Vector3 direction)
    {
        _movement.Move(direction);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out ITrashBlockStack stack))
        {
            var block = stack.Get();
            _resourcesStack.Add(block);
        }
    }
}
