using PixupGames.Infrastracture.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyZone : MonoBehaviour, IBuyZone
{
    [SerializeField] private int _id;
    [SerializeField] private int _totalCost = 100;
    [SerializeField] private Commodity _template;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private TMP_Text _totalCostLabel;
    [SerializeField] private BuyZoneTrigger _trigger;
    [SerializeField] private ParticleSystem _unlockEffect;
 
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

    public int Id => _id;

    public void Hide() => Destroy(gameObject);

    public void Show() => gameObject.SetActive(true);

    private void OnExit(IPlayer player)
    {
        StopCoroutine(_tryBuyCoroutine);
    }

    private void OnEntered(IPlayer player)
    {
        if (_tryBuyCoroutine != null)
            StopCoroutine(_tryBuyCoroutine);

        _tryBuyCoroutine = StartCoroutine(TryBuy(player.Wallet, player.Character.Movement));
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
                    UnlockCommodity(true);
            }

            iteration++;
            yield return null;
        }
    }

    public void UnlockCommodity(bool animate)
    {
        if (_tryBuyCoroutine != null)
            StopCoroutine(_tryBuyCoroutine);

        var particle = Instantiate(_unlockEffect, _spawnPoint.position, Quaternion.identity);
        particle.Play();

        var commodity = Instantiate(_template, _spawnPoint.position, transform.rotation);
        commodity.Show(animate);

        Hide();
    }
}
