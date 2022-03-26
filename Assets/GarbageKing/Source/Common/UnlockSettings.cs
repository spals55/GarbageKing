using DG.Tweening;
using System;
using UnityEngine;

[Serializable]
public class UnlockSettings
{
    [SerializeField] private float _duration;
    [SerializeField] private Ease _ease = Ease.Unset;

    public float Duration => _duration;
    public Ease Ease => _ease;
}