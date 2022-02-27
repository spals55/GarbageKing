using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Money : MonoBehaviour
{
    [SerializeField] private int _amount;

    public int Amount => _amount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IPlayer character))
        {
            ////На первое время.
            transform.DOMove(new Vector3(character.transform.position.x, character.transform.position.y + 2, character.transform.position.z), 0.2f);
            transform.DOScale(Vector3.zero, 0.5f);

            Destroy(gameObject, 0.2f);
        }
    }
}
