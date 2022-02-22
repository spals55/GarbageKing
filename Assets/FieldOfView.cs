using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField, Range(0, 360)] private float _angle;
    [SerializeField] private Transform _startPoint;

    public float Distance => _distance;
    public float Angle => _angle;
    public Transform StartPoint => _startPoint;

    public Vector3 DirectionFromAngle(float angle, bool isGlobal)
    {
        if(!isGlobal)
            angle += transform.eulerAngles.y;

        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }
}
