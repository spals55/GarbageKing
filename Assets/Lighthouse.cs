using DG.Tweening;
using PixupGames.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : MonoBehaviour
{
    [SerializeField] private LighthouseTrigger _trigger;
    [SerializeField] private List<MeshRenderer> _meshRenderers;

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
        foreach (var meshRender in _meshRenderers)
            meshRender.enabled = false;
    }

    private void OnExit(IHero hero)
    {
        foreach (var meshRender in _meshRenderers)
            meshRender.enabled = true;
    }
}
