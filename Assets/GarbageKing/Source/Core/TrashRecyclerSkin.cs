using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashRecyclerSkin : MonoBehaviour
{
    [SerializeField] private Transform _box;
    [SerializeField] private float _shakeDuration = 2.5f;
    [SerializeField] private float _shakeStrenght = 20f;
    
    public void ShakeBox()
    {
        _box.DOShakeScale(_shakeDuration, _shakeStrenght);
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
