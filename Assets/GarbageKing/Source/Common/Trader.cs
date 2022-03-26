using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Wave()
    {
        _animator.SetTrigger("Wave");
    }
}
