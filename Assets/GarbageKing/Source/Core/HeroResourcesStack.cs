using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroResourcesStack : MonoBehaviour
{
    [SerializeField] private float _offsetY;
    [SerializeField] private Transform _container;
    [SerializeField] private float _animationDuration;

    private Vector3 _lastTopPosition;
    private int _lastChildCount;

    private Stack<ITrashBlock> _blocksStack = new Stack<ITrashBlock>();
    private List<Transform> _transforms = new List<Transform>();

    public void Add(ITrashBlock stackable)
    {
        Vector3 endPosition = CalculateAddEndPosition(_container, stackable.transform);
        Vector3 endRotation = Vector3.zero;
        Vector3 defaultScale = stackable.transform.localScale;

        stackable.transform.DOComplete(true);
        stackable.transform.parent = _container;

        stackable.transform.DOLocalMove(endPosition, _animationDuration);
        stackable.transform.DOLocalRotate(endRotation, _animationDuration);

        stackable.transform.DOLocalJump(endPosition, 2f, 1, _animationDuration);

        _transforms.Add(stackable.transform);
        _blocksStack.Push(stackable);
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

        return block;
    }

    private Vector3 CalculateAddEndPosition(Transform container, Transform stackable)
    {
        var stackableLocalScale = container.InverseTransformVector(stackable.lossyScale);
        var endPosition = new Vector3(0, stackableLocalScale.y / 2, 0);

        if (container.childCount > _lastChildCount)
        {
            endPosition += _lastTopPosition;
        }
        else if (container.childCount != 0)
        {
            Transform topStackable = FindTopStackable(container);
            Vector3 topPosition = new Vector3(0, topStackable.localPosition.y + topStackable.localScale.y / 2, 0);

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
}
