using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour, IControlledCharacter
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _rotationSpeed = 10f;

    public float Velocity => _characterController.velocity.magnitude;

    public void ChangeSpeed(int speed)
    {
        if (speed < 0)
            throw new ArgumentException();
    }

    public void Move(Vector3 direction)
    {
        MoveRotation(direction);
        _characterController.Move(direction * Time.deltaTime * _speed);
    }

    private void MoveRotation(Vector3 direction)
    {
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = GetSmoothRotation(rotation);
    }

    private Quaternion GetSmoothRotation(Quaternion targetRotation) =>
        Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
}
