using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PixupGames.Infrastracture.Game
{
    public class PlayGameWindow : MonoBehaviour, IPlayGameWindow
    {
        [SerializeField] private TMP_Text _moneyLabel;
        [SerializeField] private TMP_Text _capacityLabel;
        [SerializeField] private Image _fill;

        public void Hide()
        {
            throw new System.NotImplementedException();
        }

        public void RenderMoney(int money)
        {
            _moneyLabel.text = money.ToString();
        }

        public void ChangeCapacity(int capacity, int maxCapacity)
        {
            if (capacity >= maxCapacity)
                _capacityLabel.text = "MAX";
            else
               _capacityLabel.text = capacity.ToString();


            _fill.fillAmount = capacity / (float)maxCapacity;
        }

        public void Show()
        {
            throw new System.NotImplementedException();
        }
    }
}