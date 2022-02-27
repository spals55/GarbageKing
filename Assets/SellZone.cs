using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellZone : MonoBehaviour
{
    [SerializeField] private TrashBlockStack _stack;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out CharacterResourcesStack stack))
        {
            var block = stack.Get();
            _stack.Add(block);
        }
    }
}
