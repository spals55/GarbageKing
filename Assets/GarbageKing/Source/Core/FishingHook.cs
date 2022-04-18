using PixupGames.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingHook : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _returnSpeed;
    [SerializeField] private float _stopRange;
    [SerializeField] private LineRenderer _fishingLine;

    private bool _isHooked;
    private Collider _hooked;

    private Coroutine _flyingToTarget;
    private Coroutine _flyingBack;

    public event Action<Collider> Returned;

    public void Fly(Vector3 startPosition, Vector3 targetPosition)
    {
        _flyingToTarget = StartCoroutine(FlyingToTarget(startPosition, targetPosition));
    }

    private IEnumerator FlyingToTarget(Vector3 startPosition, Vector3 targetPosition)
    {
        while (true)
        {
            RenderFishingLine(transform.position, startPosition);
            transform.LookAt(targetPosition);

            if (_hooked || Vector3.Distance(transform.position, startPosition) >= _stopRange)
            {
                _flyingBack = StartCoroutine(FlyingBack(startPosition));

                StopCoroutine(_flyingToTarget);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
            }

            yield return null;
        }
    }

    private IEnumerator FlyingBack(Vector3 startPosition)
    {
        while (transform.position != startPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, _returnSpeed * Time.deltaTime);
            RenderFishingLine(transform.position, startPosition);

            yield return null;
        }

        Returned?.Invoke(_hooked);
    }

    private void RenderFishingLine(Vector3 currentPosition, Vector3 startPosition)
    {
        _fishingLine.SetPosition(0, startPosition);
        _fishingLine.SetPosition(1, currentPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        _isHooked = true;
        _hooked = other;

        if (other.TryGetComponent(out Trash trash))
        {
            trash.transform.parent = transform;
        }

        if (other.TryGetComponent(out IWater water))
        {
            water.PlaySplashEffect(transform.position);
        }
    }
}
