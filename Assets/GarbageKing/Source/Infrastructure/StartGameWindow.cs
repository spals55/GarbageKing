using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public class StartGameWindow : MonoBehaviour, IStartGameWindow
    {
        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void Open()
        {
            return;
        }
    }
}