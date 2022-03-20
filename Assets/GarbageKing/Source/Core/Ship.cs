using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class Ship : MonoBehaviour
{
    [SerializeField] private TrashBlockStack _trashBlockStack;
    [SerializeField] private Transform _reloadPoint;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private MoneyStack _moneyStack;
    [SerializeField] private ParticleSystem _boughtEffect;
    [SerializeField] private ObjectPool _pool;

    private ShipState _currentState;

    public bool CanAdd => _trashBlockStack.IsFull == false 
        && _currentState == ShipState.Ready;

    public void Add(ITrashBlock block)
    {
        _trashBlockStack.Add(block);

        if (CanAdd == false)
            EndShipment();
    }

    private async void EndShipment()
    {
        _boughtEffect.Play();

        await Pay();

        Reload();
    }

    private async Task Pay()
    {
        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(100);
            var money = _pool.Get(transform.position);
            _moneyStack.Add(money);
        }
    }

    public void Reload()
    {
        float duration = 3f;

        _currentState = ShipState.Reload;

        transform.DORotate(_reloadPoint.rotation.eulerAngles, duration);
        transform.DOMove(_reloadPoint.transform.position, duration)
            .OnComplete(() =>
            {
                Clean();
                MoveBack();
            });
    }

    private void MoveBack()
    {
        float duration = 1f;

        transform.DORotate(_startPoint.rotation.eulerAngles, duration);
        transform.DOMove(_startPoint.transform.position, duration)
            .OnComplete(() =>
            {
                _currentState = ShipState.Ready;
            });
    }

    private void Clean()
    {
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
    Reload,
}
