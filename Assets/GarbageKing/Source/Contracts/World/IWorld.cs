using PixupGames.Contracts;
using PixupGames.Infrastracture.Game;
using PixupGames.Infrastracture.Services;
using UnityEngine;

public interface IWorld
{
    ICamera Camera { get; }

    void RespawnHero(Vector3 position);
    IHero SpawnHero(Vector3 position);
    void UnlockRegion(string guid);
}
