using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MoneyStack : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3Int _countStack;
    [SerializeField] private Transform _stackContainer;
    [SerializeField] private float _jumpPower = 1f;
    [SerializeField] private float _jumpDuration = 1f;

    private List<Transform> _transforms = new List<Transform>();
    private Stack<Money> _trashBlocks = new Stack<Money>();
    private Vector3Int _currentCountStack = new Vector3Int(1, 1, 1);
    private int _topStackables = 0;

    public bool IsFull => _trashBlocks.Count >= _capacity;
    public bool CanGet => _trashBlocks.Count > 0;

    public void Add(Money block)
    {
        Vector3 endPosition = CalculateAddEndPosition(_stackContainer.transform, block.transform);
        Vector3 endRotation = new Vector3(-90, 0, 0);

        block.transform.DOComplete(true);
        block.transform.parent = _stackContainer;

        block.transform.DOLocalRotate(endRotation, 1);
        block.transform.DOLocalJump(endPosition, _jumpPower, 1, _jumpDuration);

        _transforms.Add(block.transform);
        _trashBlocks.Push(block);
    }

    public Money Get()
    {
        var block = _trashBlocks.Pop();

        block.transform.DOComplete(true);
        block.transform.parent = null;

        int removedIndex = _transforms.IndexOf(block.transform);
        _transforms.RemoveAt(removedIndex);
        RecalculatePosition();

        return block;
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