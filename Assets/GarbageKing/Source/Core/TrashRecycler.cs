using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashRecycler : Commodity, ITrashRecycler
{
    [SerializeField] private DropTrigger _dropTrigger;

    private Coroutine _tryCollectTrash;

    private void OnEnable()
    {
        _dropTrigger.Entered += OnDropTriggerEntered;
        _dropTrigger.Exit += OnDropTriggerExit;
    }


    private void OnDisable()
    {
        _dropTrigger.Entered -= OnDropTriggerEntered;
        _dropTrigger.Exit -= OnDropTriggerExit;
    }

    public override void Show(bool animate)
    {
        gameObject.SetActive(true);

        if (animate)
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(1f, 1f);
        }
    }

    private void OnDropTriggerEntered(ICharacter character)
    {
        if (_tryCollectTrash != null)
            StopCoroutine(_tryCollectTrash);

        _tryCollectTrash = StartCoroutine(TryCollectTrash(character.Bag));
    }

    private void OnDropTriggerExit(ICharacter character)
    {
        StopCoroutine(_tryCollectTrash);
    }

    private IEnumerator TryCollectTrash(IGarbageBag bag)
    {
        while (true)
        {
            if (bag.HasTrash)
            {
               var trash = bag.Get();             
            }

            yield return null;
        }
    }
}
