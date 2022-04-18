using PixupGames.Contracts;
using PixupGames.Core;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour, IVehicle
{
    public abstract void Enter(IHero hero);

    public abstract void Exit();

    public abstract void Move(Vector3 direction);
}