using System;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

public abstract class Zone : GUIDSaveObject
{
    public void Hide() => Destroy(gameObject);

    public void Show() => gameObject.SetActive(true);

    public abstract void Buy(bool animate, bool save);
}
