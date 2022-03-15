using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chest : MonoBehaviour, IChest
{
    [SerializeField] private Transform _lid;

    public void Open()
    {
        _lid.transform.DOLocalRotate(new Vector3(-90, 0, 0), 1f);
    }

    public void Close()
    {
        _lid.transform.DOLocalRotate(new Vector3(0, 0, 0), 1f);
    }
}
