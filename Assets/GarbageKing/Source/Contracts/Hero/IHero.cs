using PixupGames.Core;
using PixupGames.Infrastracture.Services;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PixupGames.Contracts
{
    public interface IHero : ICharacter, ICameraTarget, IControlled
    {
        GarbageBag Bag { get; }
        GarbageCollector GarbageCollector { get; }
        IHeroAnimation Animation { get; }
        IMovement Movement { get; }
        IWallet Wallet { get; }

        event Action<IVehicle> SatVehicle;

        void SitDownIn(IVehicle vehicle);
    }
}

public interface IHeroAnimation
{

}