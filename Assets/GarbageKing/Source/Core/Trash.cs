using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : GUIDSaveObject
{
    [SerializeField] private TrashType _type;
    [SerializeField] private int _weight;
    [SerializeField] private Collider _collider;

    public TrashType Type => _type;

    public int Weight => _weight;

    public bool CanCollect { get; private set; } = true;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(GUID))
        {
            Hide();
        }
    }

    public void Hide() => gameObject.SetActive(false);

    public void Collect()
    {
        CanCollect = false;
        _collider.enabled = false;
        PlayerPrefs.SetString(GUID, GUID);
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
