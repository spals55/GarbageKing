﻿using UnityEngine;

public abstract class PoolElement : MonoBehaviour
{
    public bool CanUse { get; private set; } = true;

    public void Show()
    {
        gameObject.SetActive(true);
        CanUse = false;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        ResetScale();
        CanUse = true;
    }

    protected abstract void ResetScale();
}

