using UnityEngine;

public class Waypathes : MonoBehaviour
{
    [SerializeField] private Transform[] _waypathes;
    [SerializeField] private Color _debugColor = Color.green;

    private int _currentWaypointIndex;

    public bool HasNext => _currentWaypointIndex + 1 < _waypathes.Length;

    public Transform Current => _waypathes[_currentWaypointIndex];

    public Transform Next()
    {
        _currentWaypointIndex++;
        return _waypathes[_currentWaypointIndex];
    }  

    public void Restart()
    {
        _currentWaypointIndex = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _debugColor;

        for (int i = 0; i < _waypathes.Length - 1; i++)
        {
            Gizmos.DrawWireSphere(_waypathes[i].position, 1f);
            Gizmos.DrawLine(_waypathes[i].position, _waypathes[i + 1].position);
        }
    }
}