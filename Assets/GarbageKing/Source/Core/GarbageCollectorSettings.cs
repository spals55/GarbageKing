using System;
using UnityEngine;

[Serializable]
public class GarbageCollectorSettings
{
    [SerializeField] private float _retractionSpeed = 12;
    [SerializeField] private float _scaleSpeed = 6;
    [SerializeField] private float _distance = 4;
    [SerializeField] private float _radius = 360;
    [SerializeField] private float _angle = 135;
    [SerializeField] private LayerMask _layerMask;

    public float RetractionSpeed => _retractionSpeed;
    public float ScaleSpeed => _scaleSpeed;
    public float Distance => _distance;
    public float Radius => _radius;
    public float Angle => _angle;
    public LayerMask LayerMask => _layerMask;
}
