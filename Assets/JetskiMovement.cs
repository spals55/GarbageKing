using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetskiMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _rotationSpeed = 10f;

    public void Move(Vector3 direction)
    {
        MoveRotation(direction);

        _rigidbody.AddForce(direction * _speed, ForceMode.Acceleration);
    }

    private void MoveRotation(Vector3 direction)
    {
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = GetSmoothRotation(rotation);
    }

    private Quaternion GetSmoothRotation(Quaternion targetRotation) =>
        Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
}
