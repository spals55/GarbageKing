using System;
using UnityEngine;

namespace PixupGames.Contracts
{
    public interface IWallet 
    {
        event Action BalanceChanged;
        int Money { get; }
        int MaxMoney { get; }
        Transform Container { get; }

        void Spend(int amount);
        void Add(int amount);
    }
}