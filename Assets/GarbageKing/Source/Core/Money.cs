using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Money : PoolElement
{
    [SerializeField] private int _amount;
    public int Amount => _amount;
}
