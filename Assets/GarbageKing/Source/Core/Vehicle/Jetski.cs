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

    public bool HasDriver { get; private set; }
    public IHero Driver { get; private set; }

    public override void Enter(IHero hero)
    {
        Analytics.SendDriveJetskiRegion();

        Driver = hero;
        hero.GarbageCollector.Disable();
        _garbageCollector.ChangeBag(hero.Bag);
        HasDriver = true;
    }

    public override void Exit()
    {
        Driver.GarbageCollector.Enable();
        _garbageCollector.ChangeBag(Driver.Bag);
        HasDriver = false;
    }

    public override void Move(Vector3 direction)
    {
        _movement.Move(direction);
    }
}
