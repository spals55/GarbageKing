using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public class StartGameWindow : MonoBehaviour, IStartGameWindow
    {
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            return;
        }
    }
}