using System;

namespace PixupGames.Infrastracture.Services
{
    public interface IWallet 
    {
        event Action BalanceChanged;
        int Coins { get; }
        int MaxCoins { get; }

        void Spend(int amount);
        void AddCoins(int amount);
    }
}