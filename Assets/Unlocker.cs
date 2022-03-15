using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnlockEffect))]
public class Unlocker : MonoBehaviour
{
    private UnlockEffect _effect;

    private void Awake()
    {
        _effect = GetComponent<UnlockEffect>();
    }

    public void Unlock(bool animate)
    {
        gameObject.SetActive(true);

        if (animate)
        {
            _effect.Play();
        }
    }
}
