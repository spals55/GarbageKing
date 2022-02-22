using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter : ICameraTarget
{
    bool Alive { get; }
    void Move(Vector3 direction);
}
