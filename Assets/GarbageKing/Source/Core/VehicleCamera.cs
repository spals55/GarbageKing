using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _translateSpeed = 9f;
    [SerializeField] private float _rotationSpeed = 200f;
    [SerializeField] private float _rotationAngleY = -12;

    [SerializeField] private Vector3 _offset;
    [SerializeField] [Range(0, 1)] private float _smooth = 0.5f;

    public void EnableCamera()
    {
        _camera.gameObject.SetActive(true);
    }

    public void Follow(ICameraTarget vehicle)
    {
        StartCoroutine(Following(vehicle));
    }

    private void Translation(ICameraTarget vehicle)
    {
        var targetPosition = vehicle.transform.position + _offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, _smooth);
    }

    private void Rotation(ICameraTarget vehicle)
    {
        var direction = vehicle.transform.position - transform.position;
        var rotation = Quaternion.LookRotation(new Vector3(direction.x, _rotationAngleY, direction.z));

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }

    private IEnumerator Following(ICameraTarget target)
    {
        while (true)
        {
            Translation(target);
            Rotation(target);

            yield return null;
        }
    }
}
