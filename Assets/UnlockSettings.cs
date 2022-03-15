using System;
using UnityEngine;

[Serializable]
public class UnlockSettings
{
    [SerializeField] private float _duration;

    public float Duration => _duration;
}