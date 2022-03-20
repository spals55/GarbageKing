using PixupGames.Infrastracture.Services;
using System.Collections;
using System.Collections.Generic;

namespace PixupGames.Contracts
{
    public interface IHero : ICharacter, ICameraTarget
    {
        IHeroAnimation Animation { get; }
        IMovement Movement { get; }
        IGarbageBag Bag { get; }
        IWallet Wallet { get; }
    }
}

public interface IHeroAnimation
{

}