using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Money _moneyTemplate;

    public Money Get(Vector3 position)
    {
        return Instantiate(_moneyTemplate, position, Quaternion.identity);
    }
}

