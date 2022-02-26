using PixupGames.Infrastracture.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    IMovement Movement { get; }
    IGarbageBag Bag { get; }

    void Move(Vector3 direction);
}
