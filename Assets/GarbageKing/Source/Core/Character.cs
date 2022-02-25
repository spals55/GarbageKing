using PixupGames.Infrastracture.Services;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement), typeof(CharacterAnimation))]
public class Character : MonoBehaviour, ICharacter
{
    [SerializeField] private CharacterMovement _movement;
    [SerializeField] private CharacterAnimation _animation;
    [SerializeField] private GarbageCollector _garbageCollector;

    private IWallet _wallet;

    public IWallet Wallet => _wallet;
    public IMovement Movement => _movement;
    public IGarbageBag Bag => _garbageCollector.Bag;

    public bool Alive => true;

    private void Awake()
    {
        _wallet = new Wallet();
        _wallet.AddCoins(2222);
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
