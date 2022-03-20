using PixupGames.Contracts;
using PixupGames.Infrastracture.Services;
using System;
using UnityEngine;

namespace PixupGames.Core
{
    public class Wallet : MonoBehaviour, IWallet
    {
        public int MaxMoney { get; private set; } = 9999;
        public int Money { get; private set; }
        public Transform Container => transform;

        public event Action BalanceChanged;

        public void Add(int amount)
        {
            if (amount + 1 > MaxMoney)
                Money = MaxMoney;

            Money += amount;
            BalanceChanged?.Invoke();
        }

        public void Spend(int amount)
        {
            if (amount > Money)
                throw new InvalidOperationException();

            Money -= amount;
            BalanceChanged?.Invoke();
        }
    }
}