using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Money : MonoBehaviour
{
    [SerializeField] private int _amount;
    [SerializeField] private Transform _target;
    public int Amount => _amount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IPlayer character))
        {
            var position = _target.position;

            var converted = Camera.main.ScreenToWorldPoint(new Vector3(_target.position.x, _target.position.y, transform.position.z));

            ////На первое время.
            transform.DOMove(converted, 0.5f);
            transform.DOScale(Vector3.zero, 1f);

            Destroy(gameObject, 1f);
        }
    }
}
