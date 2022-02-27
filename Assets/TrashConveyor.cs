using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashConveyor : MonoBehaviour, ITrashConveyor
{
    [SerializeField] private TrashBlockStack _stack;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speed;

    public void Add(ITrashBlock block)
    {
        StartCoroutine(MovementToStack(block));
    }

    public IEnumerator MovementToStack(ITrashBlock block)
    {
        block.transform.position = _startPoint.position;
        block.transform.rotation = _startPoint.rotation;

        while (block.transform.position != _endPoint.position)
        {
            block.transform.position = Vector3.MoveTowards(block.transform.position,
                _endPoint.position, _speed * Time.deltaTime);

            yield return null;
        }

        _stack.Add(block);
    }
}
