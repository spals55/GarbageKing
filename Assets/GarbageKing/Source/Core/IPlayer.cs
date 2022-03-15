using PixupGames.Contracts;
using PixupGames.Infrastracture.Game;
using PixupGames.Infrastracture.Services;
using System;

public interface IPlayer : IFixedUpdateLoop
{
    event Action ControlledHeroDead;
    public IHero ControlledHero { get; set; }
}
