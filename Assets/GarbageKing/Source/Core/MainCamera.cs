using PixupGames.Infrastracture.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour, ICamera
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] [Range(0, 1)] private float _smooth = 0.5f;
    [SerializeField] private float _forwardOffsetMultiplier = 10f;

    private IControlledCharacter _target;

    public void FixedUpdateLogic(float tick)
    {
        //var targetPosition = (_target.transform.forward * _forwardOffsetMultiplier) + _target.transform.position + _offset;
        //transform.position = Vector3.Lerp(transform.position, targetPosition, _smooth);
    }

    public void SetTarget(IControlledCharacter target)
    {
        _target = target;
        //_offset = transform.position - _target.transform.position;
    }
}
