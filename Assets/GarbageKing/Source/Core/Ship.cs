using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class Ship : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _rotationDuration;
    [SerializeField] private TrashBlockStack _trashBlockStack;
    [SerializeField] private Waypathes _waypoints;
    [SerializeField] private int _boughtPrice;

    private ShipState _currentState;

    public bool CanAdd => _trashBlockStack.IsFull == false && _currentState == ShipState.Ready;

    public int BoughtPrice => _boughtPrice;

    private void Update()
    {
        if (_trashBlockStack.IsFull)
        {
            if (transform.position != _waypoints.Current.position)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    _waypoints.Current.position, _speed * Time.deltaTime);

                transform.rotation = Quaternion.Lerp(transform.rotation,
                    _waypoints.Current.rotation, Time.deltaTime * _rotationSpeed);
            }
            else
            {
                if (_waypoints.HasNext)
                {
                    _waypoints.Next();
                }
                else
                {
                    Reload();
                }
            }
        }
    }

    public void Add(ITrashBlock block)
    {
        _trashBlockStack.Add(block);
    }

    private void Reload()
    {
        _currentState = ShipState.Ready;

        while (_trashBlockStack.CanGet)
        {
            var block = _trashBlockStack.Get();
            block.Hide();
        }
    }
}

public enum ShipState
{
    Ready,
    Leave,
    Comeback
}
