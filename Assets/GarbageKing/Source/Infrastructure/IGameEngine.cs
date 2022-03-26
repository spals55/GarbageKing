using PixupGames.Infrastracture.Services;
using System.Collections;
using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public interface IGameEngine
    {
        IInputDevice GetInputDevice();
        Coroutine StartCoroutine(IEnumerator corutine);
        void StopCoroutine(Coroutine coroutine);
    }
}