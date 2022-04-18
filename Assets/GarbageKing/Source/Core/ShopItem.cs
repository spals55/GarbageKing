using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private Button _buyButton;
    [SerializeField] private TMP_Text _levelLabel;
    [SerializeField] private TMP_Text _priceLabel;
    [SerializeField] private ShopItemType _type;
    [SerializeField] private int[] _sellPrices;
    [SerializeField] private int[] _modificationValues;

    private int _currentLevel;

    public ShopItemType Type => _type;
    public int MaxLevel => _sellPrices.Length;
    public int SellPrice => _sellPrices[_currentLevel];
    public int ModicicationValue => _modificationValues[_currentLevel];
    private bool IsMaxLevel => _currentLevel + 1 >= MaxLevel;

    public event Action<ShopItem> BuyButtonClicked;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnBuyButtonClicked);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnBuyButtonClicked);
    }

    public void Init()
    {
        if (PlayerPrefs.HasKey($"{_type}"))
            _currentLevel = PlayerPrefs.GetInt($"{_type}");
        else
            _currentLevel = 0;

        if (IsMaxLevel)
            _buyButton.interactable = false;
        else
            _buyButton.interactable = true;

        _levelLabel.text = $"{_currentLevel} lvl";
        _priceLabel.text = SellPrice.ToString();
    }

    public void Upgrade()
    {
        _currentLevel++;
        _levelLabel.text = $"{_currentLevel} lvl";
        _priceLabel.text = SellPrice.ToString();

        PlayerPrefs.SetInt($"{_type}", _currentLevel);

        if (IsMaxLevel)
            _buyButton.interactable = false;
        else
            _buyButton.interactable = true;
    }

    private void OnBuyButtonClicked()
    {
        BuyButtonClicked?.Invoke(this);
    }
}