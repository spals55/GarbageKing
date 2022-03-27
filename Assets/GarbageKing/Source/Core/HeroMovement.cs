using System;
using UnityEngine;

public class HeroMovement : MonoBehaviour, IMovement
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private float _gravity = 0.5f;

    public float Velocity => _rigidbody.velocity.magnitude;

    public bool Stopped => Velocity < 0.1f;

    public void ChangeSpeed(int speed)
    {
        if (speed < 0)
            throw new ArgumentException();
    }

    public void Move(Vector3 direction)
    {
        MoveRotation(direction);

        direction.y -= _gravity;
        _rigidbody.velocity = direction * _speed;
    }

    public void SetKinematic(bool isKinematic)
    {
        _rigidbody.isKinematic = isKinematic;
    }

    private void MoveRotation(Vector3 direction)
    {
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = GetSmoothRotation(rotation);
    }

    private Quaternion GetSmoothRotation(Quaternion targetRotation) =>
        Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
}
