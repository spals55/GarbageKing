using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using PixupGames.Infrastracture.Services;
using PixupGames.Infrastracture.Game;
using PixupGames.Contracts;
using PixupGames.Core;

public class Player : IPlayer, IFixedUpdateLoop
{
    private readonly IInputDevice _inputDevice;

    private IHero _controlledHero;
    private IControlled _controlled;
    private Vector3 _direction;

    public Player(IInputDevice inputDevice)
    {
        _inputDevice = inputDevice;

        _direction = new Vector3();
    }

    ~Player()
    {
        _controlledHero.SatVehicle -= OnHeroSetVehicle;
        _controlledHero.GotOutVehicle -= OnHeroGotOutVehicle;
    }

    public IHero ControlledHero
    {
        get
        {
            if (_controlledHero == null)
                throw new NullReferenceException("Set Controlled Hero");

            return _controlledHero;
        }
        set
        {
            _controlledHero = value;
            _controlled = _controlledHero;
            _controlledHero.Dead += (() => ControlledHeroDead?.Invoke());
            _controlledHero.SatVehicle += OnHeroSetVehicle;
            _controlledHero.GotOutVehicle += OnHeroGotOutVehicle;
        }
    }

    public event Action ControlledHeroDead;

    public void FixedTick(float time)
    {
        if (_inputDevice.Axis.magnitude > Constants.Math.Epsilon)
        {
            _direction.x = _inputDevice.Axis.x;
            _direction.z = _inputDevice.Axis.y;

            _controlled.Move(_direction);
        }
    }

    private void OnHeroSetVehicle(IVehicle vehicle)
    {
        _controlled = vehicle;
    }

    private void OnHeroGotOutVehicle()
    {
        _controlled = _controlledHero;
    }
}
