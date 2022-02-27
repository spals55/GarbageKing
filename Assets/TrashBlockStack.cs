using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrashBlockStack : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3Int _countStack;
    [SerializeField] private Transform _stackContainer;

    private List<Transform> _transforms = new List<Transform>();
    private Stack<ITrashBlock> _trashBlocks = new Stack<ITrashBlock>();
    private Vector3Int _currentCountStack = new Vector3Int(1, 1, 1);
    private int _topStackables = 0;

    public bool IsFull => _trashBlocks.Count >= _capacity;

    public void Add(ITrashBlock block)
    {
        Vector3 endPosition = CalculateAddEndPosition(_stackContainer.transform, block.transform);
        block.transform.DOPunchScale(Vector3.one * 0.3f, 1f);
        block.transform.parent = _stackContainer;
        block.transform.DOLocalJump(endPosition, 1, 1, 1f);

        _trashBlocks.Push(block);
    }

    public void Remove()
    {
        var block = _trashBlocks.Pop();

        block.transform.DOComplete(true);
        block.transform.parent = null;

        int removedIndex = _transforms.IndexOf(block.transform);
        _transforms.RemoveAt(removedIndex);
    }

    private void RecalculatePosition()
    {
        _currentCountStack.x -= 1;

        if (_currentCountStack.x < 1)
        {
            _currentCountStack.x = _countStack.x;
            _currentCountStack.z -= 1;
        }

        if (_currentCountStack.z < 1)
        {
            _currentCountStack.z = _countStack.z;

            if (_topStackables == 0)
            {
                if (_currentCountStack.y > 1)
                    _currentCountStack.y -= 1;
            }
            else
            {
                _topStackables -= 1;
            }
        }
    }

    private Vector3 CalculateAddEndPosition(Transform container, Transform stackable)
    {
        Vector3 stackableLocalScale = container.InverseTransformVector(stackable.lossyScale);

        var endPosition = stackableLocalScale / 2;
        endPosition.x += (stackableLocalScale.x + _offset.x) * (_countStack.x / 2 - _currentCountStack.x);
        endPosition.y += (stackableLocalScale.y + _offset.y) * (_currentCountStack.y - 1);
        endPosition.z += (stackableLocalScale.z + _offset.z) * (_countStack.z / 2 - _currentCountStack.z);

        _currentCountStack.x += 1;

        if (_currentCountStack.x > _countStack.x)
        {
            _currentCountStack.x = 1;
            _currentCountStack.z += 1;
        }

        if (_currentCountStack.z > _countStack.z)
        {
            _currentCountStack.z = 1;

            if (_currentCountStack.y < _countStack.y)
                _currentCountStack.y += 1;
            else
                _topStackables += 1;
        }

        return endPosition;
    }
}
