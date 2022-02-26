using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public class AssetsFactory : IAssetsFactory
    {
        public T Load<T>()
        {
            return default(T);
        }
    }
}