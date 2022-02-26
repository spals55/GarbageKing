using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using PixupGames.Infrastracture.Services;
using PixupGames.Infrastracture.Game;

public class Player : MonoBehaviour, IPlayer
{
    [SerializeField] private Character _controlledCharacter;

    private IPlayGameWindow _playGameWindow;
    private IInputDevice _inputDevice;
    private IWallet _wallet;
    private Vector3 _direction = new Vector3();

    public IWallet Wallet => _wallet;
    public bool ControlledCharacterDead { get; private set; }

    public ICharacter Character
    {
        get
        {
            if (_controlledCharacter != null)
                return _controlledCharacter;
            else
                throw new NullReferenceException("You need to initialize the Controlled Character before using it");
        }
    }

    public void Init(IInputDevice inputDevice, IPlayGameWindow playGameWindow, IWallet wallet)
    {
        _playGameWindow = playGameWindow;
        _inputDevice = inputDevice;
        _wallet = wallet;
    }

    private void FixedUpdate()
    {
        if (_inputDevice.Axis.magnitude > Constants.Math.Epsilon)
        {
            _direction.x = _inputDevice.Axis.x;
            _direction.z = _inputDevice.Axis.y;

            _controlledCharacter.Move(_direction);
        }
    }
}
