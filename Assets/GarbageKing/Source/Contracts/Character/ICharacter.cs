using PixupGames.Infrastracture.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter : ICameraTarget
{
    bool Alive { get; }
    IWallet Wallet { get; }
    IMovement Movement { get; }

    void Move(Vector3 direction);
}
