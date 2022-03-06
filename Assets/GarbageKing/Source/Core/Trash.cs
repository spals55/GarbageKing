using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour, ITrash
{
    [SerializeField] private TrashType _type;
    [SerializeField] private int _weight;
    [SerializeField] private Collider _collider;

    public TrashType Type => _type;

    public int Weight => _weight;

    public bool CanCollect { get; private set; } = true;

    public void Hide() => gameObject.SetActive(false);

    public void Collect()
    {
        CanCollect = false;
        _collider.enabled = false;
    }

    public void Show()
    {
        transform.localScale = Vector3.one;
        gameObject.SetActive(true);
    }

    public void Release()
    {
        Hide();
        gameObject.SetActive(false);
    }
}
