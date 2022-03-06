using PixupGames.Contracts;
using PixupGames.Infrastracture.Game;
using PixupGames.Infrastracture.Services;
using UnityEngine;

public interface IWorld
{
    IHero CreateHero(Vector3 position);
    void UnlockRegion(string guid);
}
