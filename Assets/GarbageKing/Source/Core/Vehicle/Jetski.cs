using SimpleInputNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetski : MonoBehaviour
{
    [SerializeField] private JetskiMovement _movement;

    private IInputDevice _inputDevice;
    private Vector3 _direction;

    public void Init(IInputDevice inputDevice)
    {
        _inputDevice = inputDevice;
        _direction = new Vector3();
    }

    private void FixedUpdate()
    {
        if (_inputDevice.Axis.magnitude > Constants.Math.Epsilon)
        {
            _direction.x = _inputDevice.Axis.x;
            _direction.z = _inputDevice.Axis.y;

            _movement.Move(_direction);
        }
    }
}
