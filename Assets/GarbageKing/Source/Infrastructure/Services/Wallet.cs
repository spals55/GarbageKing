using System;
using UnityEngine;

namespace PixupGames.Infrastracture.Services
{
    public class Wallet : IWallet
    {
        public int MaxCoins { get; private set; } = 9999;
        public int Coins { get; private set; }

        public event Action CoinsChanged;

        public void AddCoins(int amount)
        {
            if (amount + 1 > MaxCoins)
                Coins = MaxCoins;

            Coins += amount;

            CoinsChanged?.Invoke();
        }

        public void Spend(int amount)
        {
            if (amount > Coins)
                throw new InvalidOperationException();

            Coins -= amount;

            CoinsChanged?.Invoke();
        }
    }
}