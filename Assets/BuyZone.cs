using PixupGames.Infrastracture.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyZone : MonoBehaviour, IBuyZone
{
    [SerializeField] private int _totalCost = 100;
    [SerializeField] private float _iteractionDelay;
    [SerializeField] private TMP_Text _totalCostLabel;
    [SerializeField] private BuyZoneTrigger _trigger;
 
    public event Action Unlocked;

    private Coroutine _tryBuyCoroutine;

#if UNITY_EDITOR
    private void OnValidate()
    {
        _totalCostLabel.text = _totalCost.ToString();
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

    public void Hide() => gameObject.SetActive(false);

    public void Show() => gameObject.SetActive(true);

    private void OnExit(ICharacter character)
    {
        StopCoroutine(_tryBuyCoroutine);
    }

    private void OnEntered(ICharacter character)
    {
        if (_tryBuyCoroutine != null)
            StopCoroutine(_tryBuyCoroutine);

        _tryBuyCoroutine = StartCoroutine(TryBuy(character.Wallet, character.Movement));
    }

    private IEnumerator TryBuy(IWallet wallet, IMovement movement)
    {
        const int IterationMultiplier = 25;
        var iteration = 0;

        while (true)
        {
            if (movement.Stopped && wallet.Coins > 0)
            {
                var multiplierCoefficient = iteration / IterationMultiplier;

                if (_totalCost < multiplierCoefficient)
                    multiplierCoefficient = _totalCost;

                multiplierCoefficient = Mathf.Clamp(multiplierCoefficient, 1, wallet.Coins);

                wallet.Spend(multiplierCoefficient);
                _totalCost -= multiplierCoefficient;
                _totalCostLabel.text = _totalCost.ToString();

                TryBought(_totalCost);
            }

            iteration++;
            yield return Yielder.WaitForSeconds(_iteractionDelay);
        }
    }

    private void TryBought(int totalCost)
    {
        if (totalCost < 1)
            Bought();
    }

    private void Bought()
    {
        Unlocked?.Invoke();
        StopCoroutine(_tryBuyCoroutine);
        Hide();
    }
}
