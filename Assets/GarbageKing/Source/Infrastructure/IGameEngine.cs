using PixupGames.Infrastracture.Services;
using System.Collections;
using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public interface IGameEngine
    {
        ICamera Camera { get; }

        IInputDevice GetInputDevice();
        IViewport GetViewport();
        Coroutine StartCoroutine(IEnumerator corutine);
        void StopCoroutine(Coroutine coroutine);
    }
}