using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour, IPlayer
{
    private ICharacter _controlledCharacter;
    private IInputDevice _inputDevice;
    private Vector3 _direction = new Vector3();

    public bool ControlledCharacterDead { get; private set; }

    public ICharacter ControlledCharacter
    {
        get
        {
            if (_controlledCharacter != null)
                return _controlledCharacter;
            else
                throw new NullReferenceException("You need to initialize the Controlled Character before using it");
        }
    }

    public void Init(IInputDevice inputDevice, ICharacter character)
    {
        _controlledCharacter = character;
        _inputDevice = inputDevice;
    }

    private void FixedUpdate()
    {
        if(ControlledCharacter.Alive)
        {
            if (_inputDevice.Axis.magnitude > Constants.Math.Epsilon)
            {
                _direction.x = _inputDevice.Axis.x;
                _direction.z = _inputDevice.Axis.y;

                _controlledCharacter.Move(_direction);
            }
        }
        else
        {
            ControlledCharacterDead = true;
        }
    }
}
