using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Money : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ICharacter character))
        {
            transform.DOMove(character.transform.position, 0.2f);
            Destroy(gameObject, 0.2f);
        }
    }
}
