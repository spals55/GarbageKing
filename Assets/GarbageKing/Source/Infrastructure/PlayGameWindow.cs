using PixupGames.Contracts;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PixupGames.Infrastracture.Game
{
    public class PlayGameWindow : MonoBehaviour, IPlayGameWindow
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TMP_Text _moneyLabel;
        [SerializeField] private TMP_Text _capacityLabel;
        [SerializeField] private Image _fill;

        private IWallet _wallet;
        private IGarbageBag _gargabeBag;

        public void Init(IWallet wallet, IGarbageBag garbageBag)
        {
            _wallet = wallet;
            _gargabeBag = garbageBag;

            UpdateGarbageCapacity();
            UpdateBalance();

            _wallet.BalanceChanged += OnBalanceChanged;
            _gargabeBag.WeightChanged += OnGarbageBagWeightChanged;
        }

        public void Show() => _canvasGroup.Open();

        public void Hide() => _canvasGroup.Close();

        private void OnGarbageBagWeightChanged()
        {
            UpdateGarbageCapacity();
        }

        private void OnBalanceChanged()
        {
            UpdateBalance();
        }

        private void UpdateGarbageCapacity()
        {
            if (_gargabeBag.Weight >= _gargabeBag.MaxWeight)
                _capacityLabel.text = "MAX";
            else
                _capacityLabel.text = _gargabeBag.Weight.ToString();

            _fill.fillAmount = _gargabeBag.Weight / (float)_gargabeBag.MaxWeight;
        }

        private void UpdateBalance()
        {
            _moneyLabel.text = _wallet.Money.ToString();
        }

        private void OnDestroy()
        {
            _wallet.BalanceChanged -= OnBalanceChanged;
            _gargabeBag.WeightChanged -= OnGarbageBagWeightChanged;
        }
    }
}
