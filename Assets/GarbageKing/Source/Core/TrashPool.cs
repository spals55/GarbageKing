using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrashPool : MonoBehaviour
{
    private List<Trash> _trash = new List<Trash>();

    private void Awake()
    {
        _trash = FindObjectsOfType<Trash>().ToList();
    }

    public ITrash Get(TrashType type, Vector3 position)
    {
        foreach (var item in _trash)
        {
             if(item.gameObject.activeSelf == false && item.Type == type)
            {
                item.Show();
                item.transform.position = position;
                return item;
            }
        }

        return null;
    }
}
