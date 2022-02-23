using System;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBag : MonoBehaviour, IGarbageBag
{
    [SerializeField] private TrashPool _pool;
    [SerializeField] private int _maxCapacity;

    private Queue<TrashType> _trash = new Queue<TrashType>();
    private int _currentCapacity;

    public bool CanAdd => _currentCapacity < _maxCapacity;
    public bool HasTrash => _currentCapacity > 0;

    public void Add(TrashType trash) => _trash.Enqueue(trash);

    public ITrash Get() => _pool.Get(_trash.Dequeue());
}

public interface IGarbageBag
{
    bool HasTrash { get; }
    bool CanAdd { get; }
    void Add(TrashType type);
    ITrash Get();
}