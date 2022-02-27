using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashRecyclerSkin : MonoBehaviour
{
    [SerializeField] private Transform _box;

    public void ShakeBox(float duration)
    {
        _box.DOShakeScale(duration, 20f);
    }

    public void Show(bool animate)
    {
        gameObject.SetActive(true);

        if (animate)
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(1f, 1f);
        }
    }
}
