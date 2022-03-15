using System;
using UnityEngine;

namespace PixupGames.Contracts
{
    public interface ICharacter
    {
        event Action Dead;

        void Move(Vector3 direction);
        ITrashBlock GetTrashBlock();
    }
}