using PixupGames.Contracts;
using PixupGames.Core;
using SimpleInputNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetski : Vehicle
{
    [SerializeField] private JetskiMovement _movement;
    [SerializeField] private GarbageCollector _garbageCollector;

    public override void Enter(IHero hero)
    {
        hero.GarbageCollector.Disable();
        _garbageCollector.ChangeBag(hero.Bag);
    }

    public override void Move(Vector3 direction)
    {
        _movement.Move(direction);
    }
}
