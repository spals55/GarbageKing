using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    [SerializeField] private int _power = 10;
    [SerializeField] private float _distance = 10;
    [SerializeField] private float _radius = 40;
    [SerializeField] private float _angle = 180;
    [SerializeField] private Transform _mouth;
    [SerializeField] private GarbageBag _bag;
    [SerializeField] private LayerMask _trashLayer;

    private bool _work = true;

    private void FixedUpdate()
    {
        if (_work)
        {
            SuckNearestTresh();
        }
    }

    public void Enable() => _work = true;

    public void Disable() => _work = false;

    private ITrash FindNearestTrash()
    {
        Collider[] trashInView = Physics.OverlapSphere(_mouth.position, _radius, _trashLayer);

        for (int i = 0; i < trashInView.Length; i++)
        {
            Transform target = trashInView[i].transform;
            Vector3 directionToTarget = (target.position - _mouth.transform.position).normalized;

            if (Vector3.Angle(_mouth.transform.forward, directionToTarget) < _angle / 2)
            {
                float distanceToTarget = Vector3.Distance(_mouth.transform.position, target.transform.position);

                if (distanceToTarget < _distance)
                {
                    if (trashInView[i].TryGetComponent(out ITrash trash))
                    {
                        if (trash.CanCollect)
                            return trash;
                    }
                }
            }
        }

        return null;
    }

    private void SuckNearestTresh()
    {
        var nearestTrash = FindNearestTrash();

        if (nearestTrash != null)
        {
            StartCoroutine(Suck(nearestTrash));
        }
    }

    private IEnumerator Suck(ITrash trash)
    {
        trash.Collect();

        while (trash.transform.position != _mouth.transform.position)
        {
            trash.transform.position = Vector3.MoveTowards(trash.transform.position, _mouth.transform.position, _power * Time.deltaTime);
            trash.transform.localScale = Vector3.MoveTowards(trash.transform.localScale, Vector3.zero, _power * Time.deltaTime);

            yield return null;
        }

        Taptic.Selection();
        _bag.Add(trash);
    }

    private Vector3 DirectionFromAngle(float angle, bool isGlobal)
    {
        if (!isGlobal)
            angle += transform.eulerAngles.y;

        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }

    private void OnDrawGizmos()
    {
        Vector3 lineA = DirectionFromAngle(-_angle / 2, false);
        Vector3 lineB = DirectionFromAngle(_angle / 2, false);

        Gizmos.color = Color.black;
        Gizmos.DrawLine(_mouth.transform.position, _mouth.transform.position + lineA * _distance);
        Gizmos.DrawLine(_mouth.transform.position, _mouth.transform.position + lineB * _distance);
    }
}
