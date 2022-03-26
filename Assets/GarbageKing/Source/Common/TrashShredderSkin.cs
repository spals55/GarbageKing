using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashShredderSkin : TrashRecyclerSkin
{
    [SerializeField] private List<Transform> _rotatingElements;
    [SerializeField] private float _rotatingSpeed;

    private Coroutine _rotatingBlades;

    public IEnumerator RotatingBlades()
    {
        while (true)
        {
            foreach (var element in _rotatingElements)
            {
                element.Rotate(new Vector3(45, 0, 0) * _rotatingSpeed * Time.deltaTime);
            }

            yield return null;
        }
    }

    public void StartRotatingBlades()
    {
        if (_rotatingBlades != null)
            StopCoroutine(_rotatingBlades);

        _rotatingBlades = StartCoroutine(RotatingBlades());
    }

    public void StopRotatingBlades()
    {
        if (_rotatingBlades != null)
            StopCoroutine(_rotatingBlades);
    }
}
