using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandStack : MonoBehaviour, IHandStack
{
    [SerializeField] private float _offsetY;
    [SerializeField] private Transform _container;
    [SerializeField] private float _animationDuration;
    [SerializeField] private int _capacity = 7;
    [SerializeField] private StackMaxIcon _stackMaxIcon;

    private Vector3 _lastTopPosition;
    private int _lastChildCount;

    private Stack<ITrashBlock> _blocksStack = new Stack<ITrashBlock>();
    private List<Transform> _transforms = new List<Transform>();

    public bool IsFull => _blocksStack.Count >= _capacity;
    public bool IsEmpty => _blocksStack.Count == 0;

    public event Action Changed;

    public void Add(ITrashBlock block)
    {
        block.transform.DOComplete(true);
        block.transform.parent = _container;

        Vector3 endPosition = CalculateAddEndPosition(_container, block.transform);
        Vector3 endRotation = Vector3.zero;

        block.transform.DOLocalRotate(endRotation, _animationDuration);
        block.transform.DOLocalJump(endPosition, 2f, 1, _animationDuration)
            .OnComplete(() => 
            {
                if (IsFull)
                    _stackMaxIcon.Show(GetHeight());
            });

        _transforms.Add(block.transform);
        _blocksStack.Push(block);

        Changed?.Invoke();
    }

    public ITrashBlock Get()
    {
        if (_blocksStack.Count < 1)
            throw new NullReferenceException("No blocks in stack");

        var block = _blocksStack.Pop();
        block.transform.DOComplete(true);
        block.transform.parent = null;

        int removedIndex = _transforms.IndexOf(block.transform);
        _transforms.RemoveAt(removedIndex);

        if (!IsFull)
            _stackMaxIcon.Hide();

        Changed?.Invoke();

        return block;
    }

    private Vector3 CalculateAddEndPosition(Transform container, Transform stackable)
    {
        Vector3 stackableLocalScale = container.InverseTransformVector(stackable.lossyScale);
        var endPosition = new Vector3(0, stackableLocalScale.y / 2, 0);

        if (container.childCount == 1)
        {
            _lastTopPosition = Vector3.zero;
            _lastChildCount = 0;
        }

        if (container.childCount > _lastChildCount)
        {
            endPosition += _lastTopPosition;
        }
        else if (container.childCount != 0)
        {
            Transform topStackable = FindTopStackable(container);
            var topPosition = new Vector3(0, topStackable.localPosition.y + topStackable.localScale.y / 2, 0);

            endPosition += topPosition;
        }

        endPosition.y += _offsetY;

        _lastChildCount = container.childCount;
        _lastTopPosition = endPosition + new Vector3(0, stackableLocalScale.y / 2, 0);

        return endPosition;
    }

    private Transform FindTopStackable(Transform container)
    {
        Transform topStackable = container.GetChild(0);

        foreach (Transform stackable in container)
            if (topStackable.position.y < stackable.position.y)
                topStackable = stackable;

        return topStackable;
    }

    private float GetHeight()
    {
        float positionY = 0f;

        foreach (var item in _transforms)
            if (item.position.y > positionY)
                positionY = item.position.y;

        return positionY;
    }
}
