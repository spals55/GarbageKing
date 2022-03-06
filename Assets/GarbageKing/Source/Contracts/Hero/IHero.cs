using PixupGames.Infrastracture.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixupGames.Contracts
{
    public interface IHero : ICameraTarget
    {
        IMovement Movement { get; }
        IGarbageBag Bag { get; }
        IWallet Wallet { get; }

        void Init(IWallet wallet);
        void Move(Vector3 direction);
    }
}