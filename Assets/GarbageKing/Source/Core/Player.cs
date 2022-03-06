using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using PixupGames.Infrastracture.Services;
using PixupGames.Infrastracture.Game;
using PixupGames.Contracts;

public class Player : IPlayer, IFixedUpdateLoop
{
    private readonly IInputDevice _inputDevice;

    private IHero _controlledHero;
    private Vector3 _direction;

    public Player(IInputDevice inputDevice)
    {
        _inputDevice = inputDevice;

        _direction = new Vector3();
    }

    public void SetControlledHero(IHero controlledHero)
    {
        _controlledHero = controlledHero;
    }

    public void FixedTick(float time)
    {
        if (_inputDevice.Axis.magnitude > Constants.Math.Epsilon)
        {
            _direction.x = _inputDevice.Axis.x;
            _direction.z = _inputDevice.Axis.y;

            _controlledHero.Move(_direction);
        }
    }
}
