using PixupGames.Contracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingZone : MonoBehaviour
{
    [SerializeField] private FishingZoneTrigger _trigger;
    [SerializeField] private Fishing _fishing;
    [SerializeField] private Timer _timer;
    [SerializeField] private float _waitTime;

    private IHero _hero;

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
        _hero = hero;
        _timer.Begin(_waitTime);
    }

    private void OnExit(IHero _)
    {
        _timer.Stop();
    }

    private void OnTimerCompleted()
    {
        _fishing.Enter(_hero);
    }
}
