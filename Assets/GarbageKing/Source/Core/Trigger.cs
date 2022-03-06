using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Trigger<T> : MonoBehaviour
{
    [SerializeField] private Collider _collider;

    [Header("Scale")]
    [SerializeField] private bool _scaleWhenEntered;
    [SerializeField] private float _scaleDuration;
    [SerializeField] private float _scaleEndValue;
    [SerializeField] private float _scaleDefaultValue;

    public event Action<T> Entered;
    public event Action<T> Stay;
    public event Action<T> Exit;

    private List<T> _enteredObjects;

    private void Awake()
    {
        _enteredObjects = new List<T>();
        _collider.isTrigger = true;
    }

    public void Disable()
    {
        _collider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out T triggered))
        {
            _enteredObjects.Add(triggered);
            Entered?.Invoke(triggered);

            if (_scaleWhenEntered)
                transform.DOScale(_scaleEndValue, _scaleDuration);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out T triggered))
        {
            Stay?.Invoke(triggered);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out T triggeredObject))
        {
            _enteredObjects.Remove(triggeredObject);
            Exit?.Invoke(triggeredObject);

            if (_scaleWhenEntered)
                transform.DOScale(1, _scaleDuration);
        }
    }
}
