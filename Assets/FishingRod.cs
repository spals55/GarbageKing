using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    [SerializeField] private FishingHook _template;
    [SerializeField] private Transform _hookSpawnPoint;

    private bool _canHook = true;
    private FishingHook _currentHook;

    public event Action<ITrash> HookedTrash;

    public void ThrowHook(Vector3 targetPosition)
    {
        if (_canHook)
        {
            _canHook = false;
            _currentHook = Instantiate(_template, _hookSpawnPoint.position, Quaternion.identity);
            _currentHook.Fly(_hookSpawnPoint.position, targetPosition);
            _currentHook.Returned += OnHoockReturned;
        }
    }

    private void OnHoockReturned(Collider collider)
    {
        _canHook = true;
        Destroy(_currentHook.gameObject);

        if (collider == null) 
            return;

        if (collider.TryGetComponent(out ITrash trash))
        {
            HookedTrash?.Invoke(trash);
        }
    }
}
