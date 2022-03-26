using PixupGames.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopZone : MonoBehaviour
{
    [SerializeField] private ShopTrigger _trigger;
    [SerializeField] private Timer _timer;
    [SerializeField] private ShopPanel _shopPanel;
    [SerializeField] private float _waitTime;

    private void OnEnable()
    {
        _trigger.Entered += OnEntered;
        _trigger.Exit += OnExit;
        _timer.Completed += OnTimerCompleted;
    }

    private void OnDisable()
    {
        _trigger.Entered -= OnEntered;
        _trigger.Exit -= OnExit;
        _timer.Completed -= OnTimerCompleted;
    }

    private void OnEntered(IHero hero)
    {
        _timer.Begin(_waitTime);
    }

    private void OnExit(IHero _)
    {
        _timer.Stop();
    }

    private void OnTimerCompleted()
    {
        _shopPanel.Show();
    }
}
