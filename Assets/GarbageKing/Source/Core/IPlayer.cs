using PixupGames.Contracts;
using PixupGames.Infrastracture.Game;
using PixupGames.Infrastracture.Services;
using System;

public interface IPlayer : IFixedUpdateLoop
{
    public IHero ControlledHero { get; set; }
    event Action ControlledHeroDead;
}
