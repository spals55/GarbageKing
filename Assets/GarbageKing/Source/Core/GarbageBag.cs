using System.Collections.Generic;
using UnityEngine;

public class GarbageBag : MonoBehaviour
{
    private List<ITrash> _trash = new List<ITrash>();

    public void Add(ITrash trash)
    {
        trash.Hide();
        trash.transform.parent = transform;
        _trash.Add(trash);
    }

    public void Remove(ITrash trash)
    {
        trash.Show();
        trash.transform.parent = null;
        _trash.Remove(trash);
    }
}