using System;

namespace PixupGames.Infrastracture.Services
{
    public interface IWallet 
    {
        event Action BalanceChanged;
        int Money { get; }
        int MaxMoney { get; }

        void Spend(int amount);
        void Add(int amount);
    }
}