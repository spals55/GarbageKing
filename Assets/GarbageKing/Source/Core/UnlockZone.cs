using DG.Tweening;
using PixupGames.Contracts;
using PixupGames.Infrastracture.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockZone : Zone
{
    [SerializeField] private int _totalCost = 100;
    [SerializeField] private TMP_Text _totalCostLabel;
    [SerializeField] private MonoBehaviour _unlockableBehavior;
    [SerializeField] private UnlockZoneTrigger _trigger;
 
    private Coroutine _tryBuyCoroutine;
    private IUnlockable _unlockable;

#if UNITY_EDITOR
    private void OnValidate()
    {
        _totalCostLabel.text = _totalCost.ToString();

        if (_unlockableBehavior is IUnlockable)
        {
            _unlockable = _unlockableBehavior as IUnlockable;
        }
        else
        {
            _unlockableBehavior = null;
        }
    }
#endif

    private void OnEnable()
    {
        _trigger.Entered += OnEntered;
        _trigger.Exit += OnExit;
    }

    private void OnDisable()
    {
        _trigger.Entered -= OnEntered;
        _trigger.Exit -= OnExit;
    }

    private void OnEntered(IHero hero)
    {
        if (_tryBuyCoroutine != null)
            StopCoroutine(_tryBuyCoroutine);

        _tryBuyCoroutine = StartCoroutine(TryBuy(hero.Wallet, hero.Movement));
    }

    private void OnExit(IHero hero)
    {
        StopCoroutine(_tryBuyCoroutine);
    }

    private IEnumerator TryBuy(IWallet wallet, IMovement movement)
    {
        const int IterationMultiplier = 15;
        var iteration = 0;

        while (true)
        {
            if (movement.Stopped && wallet.Money > 0)
            {
                var multiplierCoefficient = iteration / IterationMultiplier;

                if (_totalCost < multiplierCoefficient)
                    multiplierCoefficient = _totalCost;

                multiplierCoefficient = Mathf.Clamp(multiplierCoefficient, 1, wallet.Money);

                wallet.Spend(multiplierCoefficient);
                _totalCost -= multiplierCoefficient;
                _totalCostLabel.text = _totalCost.ToString();

                if (_totalCost < 1)
                    Unlock(true);
            }

            iteration++;
            yield return null;
        }
    }

    public override void Unlock(bool animate)
    {
        if (_tryBuyCoroutine != null)
            StopCoroutine(_tryBuyCoroutine);

        _unlockable.Unlock(animate);
        Hide();
    }
}
