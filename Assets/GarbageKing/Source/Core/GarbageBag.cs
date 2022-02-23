using System;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBag : MonoBehaviour, IGarbageBag
{
    [SerializeField] private TrashPool _pool;
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] private int _maxCapacity;

    private const string CapacityShapeName = "Key 1";

    private Queue<ITrash> _trash = new Queue<ITrash>();
    private int _currentCapacity;

    public bool CanAdd(int weight) => _currentCapacity + weight < _maxCapacity;
    public bool HasTrash => _currentCapacity > 0;

    public void Add(ITrash trash)
    {
        trash.Hide();
        _currentCapacity += trash.Weight;
        ChangeWeight(_currentCapacity);

        _trash.Enqueue(trash);
    }

    public ITrash Get()
    {
        ITrash trash = _trash.Dequeue();
        _currentCapacity -= trash.Weight;
        ChangeWeight(_currentCapacity);

        return _pool.Get(trash.Type);
    }

    private void ChangeWeight(int currentCapacity)
    {
        var blendShapeIndex = _skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(CapacityShapeName);
        _skinnedMeshRenderer.SetBlendShapeWeight(blendShapeIndex, currentCapacity);
    }
}
