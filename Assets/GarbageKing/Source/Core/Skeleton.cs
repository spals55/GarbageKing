using PixupGames.Contracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Coroutine _moveToTarget;
    private Vector3 _startPoint;

    private void Awake()
    {
        _startPoint = transform.position;
    }

    private IEnumerator MoveToTarget(IHero target)
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _speed * Time.deltaTime);
            transform.LookAt(target.transform);

            yield return null;
        }
    }

    private IEnumerator MoveToStartPoint()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPoint, _speed * Time.deltaTime);
            transform.LookAt(_startPoint);

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHero hero))
        {
            if (_moveToTarget != null)
                StopCoroutine(_moveToTarget);

            _moveToTarget = StartCoroutine(MoveToTarget(hero));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IHero hero))
        {
            if (_moveToTarget != null)
                StopCoroutine(_moveToTarget);

            StartCoroutine(MoveToStartPoint());
        }
    }
}
