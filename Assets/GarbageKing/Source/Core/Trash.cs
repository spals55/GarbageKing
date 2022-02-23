using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour, ITrash
{
    [SerializeField] private TrashType _type;
    [SerializeField] private int _weight;

    public TrashType Type => _type;

    public int Weight => _weight;

    public bool CanCollect { get; private set; } = true;

    public void Collect() => CanCollect = false;

    public void Hide() => gameObject.SetActive(false);

    public void Show() => gameObject.SetActive(true);

    public void Release()
    {
        CanCollect = false;
        Hide();
    }
}
