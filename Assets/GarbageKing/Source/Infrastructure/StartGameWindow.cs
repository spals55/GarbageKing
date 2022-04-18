using System.Collections;
using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public class StartGameWindow : MonoBehaviour, IStartGameWindow
    {
        private void Awake()
        {
            StartCoroutine(PlayingTutorial());
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void Open()
        {
            return;
        }

        private IEnumerator PlayingTutorial()
        {
            bool work = true;

            while (work)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Close();
                    work = false;
                }

                yield return null;
            }
        }
    }
}