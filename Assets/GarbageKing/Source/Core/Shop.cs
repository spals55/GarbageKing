using PixupGames.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<ShopItem> _shopItems;

    private IHero _hero;

    private void OnEnable()
    {
        foreach (var shopItem in _shopItems)
        {
            shopItem.BuyButtonClicked += OnBuyButtonClicked;
        }
    }

    private void OnDisable()
    {
        foreach (var shopItem in _shopItems)
        {
            shopItem.BuyButtonClicked -= OnBuyButtonClicked;
        }
    }

    private void OnBuyButtonClicked(ShopItem item)
    {
        if (_hero.Wallet.Money >= item.SellPrice)
        {
            _hero.Wallet.Spend(item.SellPrice);
            item.Upgrade();
            UpgradeHero(item);
            Taptic.Success();
        }
        else
        {
            Taptic.Failure();
        }
    }

    public void Init(IHero hero)
    {
        _hero = hero;

        foreach (var item in _shopItems)
            item.Init();

        _hero.HandStack.ChangeCapacity(_shopItems[0].ModicicationValue);
        _hero.Bag.ChangeCapacity(_shopItems[1].ModicicationValue);
    }

    private void UpgradeHero(ShopItem item)
    {
        switch (item.Type)
        {
            case ShopItemType.TakeCapacity:
                _hero.HandStack.ChangeCapacity(item.ModicicationValue);
                break;
            case ShopItemType.BagCapacity:
                _hero.Bag.ChangeCapacity(item.ModicicationValue);
                break;
            default:
                break;
        }
    }
}
