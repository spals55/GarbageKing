using System;

namespace PixupGames.Infrastracture.Services
{
    public interface IWallet 
    {
        int Coins { get; }
        int MaxCoins { get; }

        event Action CoinsChanged;
        void Spend(int amount);
        void AddCoins(int amount);
    }
}