using PixupGames.Contracts;
using UnityEngine;

namespace PixupGames.Core
{
    public interface IVehicle : IControlled
    {
        Transform transform { get; }

        void Enter(IHero hero);
    }
}