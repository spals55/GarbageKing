using DG.Tweening;
using PixupGames.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrashRecycler : MonoBehaviour
{
    [SerializeField] protected int TrashWeightToCreateBlock;
    [SerializeField] protected Timer Timer;
    [SerializeField] protected TrashBlock TrashBlockTemplate;

    [SerializeField] private float _delayBetweenTrashCollect;
    [SerializeField] private DropTrigger _dropTrigger;
    [SerializeField] private Transform _trashContainer;

    protected int CurrentBlocksWeight;
    protected Queue<ITrash> TrashQueue;

    private Coroutine _tryCollectTrash;

    protected bool CanCreateBlock => CurrentBlocksWeight >= TrashWeightToCreateBlock;

    private void Awake()
    {
        TrashQueue = new Queue<ITrash>();
    }

    private void OnEnable()
    {
        Timer.Completed += OnTimerCompleted;
        _dropTrigger.Entered += OnDropTriggerEntered;
        _dropTrigger.Exit += OnDropTriggerExit;
    }

    private void OnDisable()
    {
        Timer.Completed -= OnTimerCompleted;
        _dropTrigger.Entered -= OnDropTriggerEntered;
        _dropTrigger.Exit -= OnDropTriggerExit;
    }

    private void Start()
    {
        StartCoroutine(RecyclingProcess());
    }

    protected abstract void CreateBlock();

    protected abstract IEnumerator RecyclingProcess();

    private void OnDropTriggerEntered(IHero hero)
    {
        if (_tryCollectTrash != null)
            StopCoroutine(_tryCollectTrash);

        _tryCollectTrash = StartCoroutine(TryCollectTrash(hero.Bag));
    }

    private void OnDropTriggerExit(IHero hero)
    {
        StopCoroutine(_tryCollectTrash);
    }

    private void OnTimerCompleted()
    {
        CreateBlock();
    }

    private IEnumerator TryCollectTrash(IGarbageBag bag)
    {
        while (true)
        {
            if (bag.HasTrash)
            {
                var trash = bag.GetTrash();

                trash.transform.parent = transform;
                trash.transform.DOScale(Vector3.zero, 4f);
                trash.transform.DOJump(_trashContainer.transform.position, 4f, 1, 1.5f)
                    .OnComplete(() =>
                    {
                        trash.Release();
                        trash.transform.DOComplete(true);
                        TrashQueue.Enqueue(trash);
                    });               
            }

            yield return Yielder.WaitForSeconds(_delayBetweenTrashCollect);
        }
    }
}
