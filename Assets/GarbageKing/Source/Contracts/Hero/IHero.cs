using PixupGames.Core;
using PixupGames.Infrastracture.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixupGames.Contracts
{
    public interface IHero : ICharacter, ICameraTarget, IControlled
    {
        GarbageBag Bag { get; }
        GarbageCollector GarbageCollector { get; }
        IHeroAnimation Animation { get; }
        IMovement Movement { get; }
        IWallet Wallet { get; }
        HandStack HandStack { get; }

        event Action<IVehicle> SatVehicle;
        event Action GotOutVehicle;

        void ExitVehicle(Vector3 position);
        void SitDownIn(IVehicle vehicle);
    }
}

public interface IHeroAnimation
{

}