using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Money : PoolElement
{
    [SerializeField] private int _amount;

    private Vector3 _defaultScale = new Vector3(1f, 2f, 1f);

    public int Amount => _amount;

    protected override void ResetScale()
    {
        transform.localScale = _defaultScale;
    }
}
