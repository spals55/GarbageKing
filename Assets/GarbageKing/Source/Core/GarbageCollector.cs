using System.Collections;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    [SerializeField] private Transform _mouth;
    [SerializeField] private GarbageBag _bag;
    [SerializeField] private ParticleSystem _retractionEffect;
    [SerializeField] private GarbageCollectorSettings _settings;

    private bool _work = true;

    public IGarbageBag Bag => _bag;

    private void FixedUpdate()
    {
        if (_work)
        {
            RetractionNearestTrash();
        }
    }

    public void Enable() => _work = true;

    public void Disable() => _work = false;

    private ITrash FindNearestTrash()
    {
        Collider[] trashInView = Physics.OverlapSphere(_mouth.position, _settings.Radius, _settings.LayerMask);

        for (int i = 0; i < trashInView.Length; i++)
        {
            Transform target = trashInView[i].transform;
            Vector3 directionToTarget = (target.position - _mouth.transform.position).normalized;

            if (Vector3.Angle(_mouth.transform.forward, directionToTarget) < _settings.Angle / 2)
            {
                float distanceToTarget = Vector3.Distance(_mouth.transform.position, target.transform.position);

                if (distanceToTarget < _settings.Distance)
                {
                    if (trashInView[i].TryGetComponent(out ITrash trash))
                    {
                        if (trash.CanCollect && _bag.CanAdd(trash.Weight))
                            return trash;
                    }
                }
            }
        }

        return null;
    }

    private void RetractionNearestTrash()
    {
        ITrash nearestTrash = FindNearestTrash();

        if (nearestTrash != null)
            StartCoroutine(Retraction(nearestTrash));
    }

    private IEnumerator Retraction(ITrash trash)
    {
        trash.Collect();
        _retractionEffect.Play();

        while (trash.transform.position != _mouth.transform.position)
        {
            trash.transform.position = Vector3.MoveTowards(trash.transform.position,
                _mouth.transform.position, _settings.RetractionSpeed * Time.deltaTime);

            trash.transform.localScale = Vector3.MoveTowards(trash.transform.localScale,
                Vector3.zero, _settings.ScaleSpeed * Time.deltaTime);

            yield return null;
        }

        Taptic.Selection();

        _retractionEffect.Stop();
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
        Vector3 lineA = DirectionFromAngle(-_settings.Angle / 2, false);
        Vector3 lineB = DirectionFromAngle(_settings.Angle / 2, false);

        Gizmos.color = Color.black;
        Gizmos.DrawLine(_mouth.transform.position, _mouth.transform.position + lineA * _settings.Distance);
        Gizmos.DrawLine(_mouth.transform.position, _mouth.transform.position + lineB * _settings.Distance);
    }
}
