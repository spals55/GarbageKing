using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public class StartGameWindow : MonoBehaviour, IStartGameWindow
    {
        public IButton GetStartGameButton()
        {
            throw new System.NotImplementedException();
        }

        public void Hide()
        {
            throw new System.NotImplementedException();
        }

        public void Show()
        {
            return;
        }
    }
}