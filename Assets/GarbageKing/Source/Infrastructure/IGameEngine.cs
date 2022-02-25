using System.Collections;
using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public interface IGameEngine
    {
        IInputDevice GetInputDevice();
        IViewport GetViewport();
        Coroutine StartCoroutine(IEnumerator corutine);
        void StopCoroutine(Coroutine coroutine);
    }
}