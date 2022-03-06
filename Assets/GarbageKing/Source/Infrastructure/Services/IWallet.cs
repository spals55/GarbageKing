using System;

namespace PixupGames.Contracts
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