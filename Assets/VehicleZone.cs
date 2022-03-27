using PixupGames.Contracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleZone : MonoBehaviour
{
    [SerializeField] private VehicleZoneTrigger _trigger;
    [SerializeField] private Timer _timer;
    [SerializeField] private float _waitTime;
    [SerializeField] private Vehicle _vehicle;

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
        _hero.SitDownIn(_vehicle);
        _vehicle.Enter(_hero);
    }
}
