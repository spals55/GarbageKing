using TMPro;
using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public class PlayGameWindow : MonoBehaviour, IPlayGameWindow
    {
        [SerializeField] private TMP_Text _moneyLabel;

        public void Hide()
        {
            throw new System.NotImplementedException();
        }

        public void RenderMoney(int money)
        {
            _moneyLabel.text = money.ToString();
        }

        public void Show()
        {
            throw new System.NotImplementedException();
        }
    }
}