using PixupGames.Contracts;
using PixupGames.Infrastracture.Game;
using PixupGames.Infrastracture.Services;

public interface IPlayer : IFixedUpdateLoop
{
    void SetControlledHero(IHero controlledHero);
}
