using PixupGames.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellZone : MonoBehaviour
{
    [SerializeField] private SellZoneTrigger _trigger;
    [SerializeField] private Ship _ship;
    [SerializeField] private int _moneyCountForFullShip;
    [SerializeField] private MoneyStack _moneyStack;
    [SerializeField] private ObjectPool _pool;

    private IHero _salesman;
    private Coroutine _trySellCoroutine;

    private void OnEnable()
    {
        _trigger.Entered += OnEnter;
        _trigger.Exit += OnExit;
    }

    private void OnDisable()
    {
        _trigger.Entered -= OnEnter;
        _trigger.Exit -= OnExit;
    }

    private void OnEnter(IHero hero)
    {
        if (_trySellCoroutine != null)
            StopCoroutine(_trySellCoroutine);

        _salesman = hero;

        _trySellCoroutine = StartCoroutine(TrySell(hero));
    }

    private IEnumerator TrySell(IHero hero)
    {
        while (true)
        {
            yield return new WaitUntil(() => _ship.CanAdd);

            var block = hero.GetTrashBlock();
            _ship.Add(block);

            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnExit(IHero hero)
    {
        if (_trySellCoroutine != null)
            StopCoroutine(_trySellCoroutine);

        _salesman = null;
    }
}
