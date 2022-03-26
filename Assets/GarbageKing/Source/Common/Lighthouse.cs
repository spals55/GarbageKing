using DG.Tweening;
using PixupGames.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : MonoBehaviour
{
    [SerializeField] private LighthouseTrigger _trigger;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Material _material;

    private Material _oldMaterial;


    private void Awake()
    {
        _oldMaterial = _meshRenderer.material;
    }

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
        _meshRenderer.material = _material; 
    }

    private void OnExit(IHero hero)
    {
        _meshRenderer.material = _oldMaterial;
    }
}
