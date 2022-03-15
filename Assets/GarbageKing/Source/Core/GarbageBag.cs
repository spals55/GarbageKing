using System;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBag : MonoBehaviour, IGarbageBag
{
    private const string CapacityShapeName = "Key 1";

    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] private int _maxWeight = 100;

    private int _currentCapacity;
    private Queue<ITrash> _trash = new Queue<ITrash>();

    public event Action WeightChanged;

    public bool HasTrash => _currentCapacity > 0;

    public int MaxWeight => _maxWeight;

    public int Weight => _currentCapacity;

    public bool CanAdd(int weight) =>
        _currentCapacity + weight <= _maxWeight;

    public void Add(ITrash trash)
    {
        trash.Hide();
        trash.transform.parent = transform;
        trash.transform.localPosition = Vector3.zero;

        _currentCapacity += trash.Weight;
        ChangeWeight(_currentCapacity);

        _trash.Enqueue(trash);
    }

    public ITrash GetTrash()
    {
        ITrash trash = _trash.Dequeue();
        trash.Show();
        _currentCapacity -= trash.Weight;
        ChangeWeight(_currentCapacity);

        return trash;
    }

    private void ChangeWeight(int currentCapacity)
    {
        var blendShapeIndex = _skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(CapacityShapeName);
        _skinnedMeshRenderer.SetBlendShapeWeight(blendShapeIndex, currentCapacity);
        WeightChanged?.Invoke();
    }
}
