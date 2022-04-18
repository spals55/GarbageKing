using PixupGames.Contracts;
using SimpleInputNamespace;
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
        [SerializeField] private Joystick _joystick;

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

        public void DisableJoystick()
        {
            _joystick.enabled = false;
            _joystick.gameObject.SetActive(false);
        }

        public void EnableJoystick()
        {
            _joystick.enabled = true;
            _joystick.gameObject.SetActive(true);
        }

        public void Open() => _canvasGroup.Open();

        public void Close() => _canvasGroup.Close();


        private void UpdateGarbageCapacity()
        {
            if (_gargabeBag.Weight >= _gargabeBag.MaxWeight)
                _capacityLabel.text = "MAX";
            else
                _capacityLabel.text = $"{_gargabeBag.Weight} / {_gargabeBag.MaxWeight}";

            _fill.fillAmount = _gargabeBag.Weight / (float)_gargabeBag.MaxWeight;
        }

        private void UpdateBalance()
        {
            _moneyLabel.text = _wallet.Money.ToString();
            _fill.fillAmount = _gargabeBag.Weight / (float)_gargabeBag.MaxWeight;
        }

        private void OnGarbageBagWeightChanged()
        {
            UpdateGarbageCapacity();
        }

        private void OnBalanceChanged()
        {
            UpdateBalance();
        }

        private void OnDestroy()
        {
            _wallet.BalanceChanged -= OnBalanceChanged;
            _gargabeBag.WeightChanged -= OnGarbageBagWeightChanged;
        }
    }
}
