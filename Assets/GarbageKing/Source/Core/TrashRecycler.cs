using DG.Tweening;
using PixupGames.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashRecycler : MonoBehaviour, ITrashRecycler
{
    [SerializeField] private Timer _timer;
    [SerializeField] private int _trashWeightToCreateBlock;
    [SerializeField] private TrashBlock _trashBlockTemplate;
    [SerializeField] private TrashConveyor _conveyor;
    [SerializeField] private TrashRecyclerSkin _skin;
    [SerializeField] private DropTrigger _dropTrigger;
    [SerializeField] private Transform _trashContainer;

    private Queue<ITrash> _trash;
    private Coroutine _tryCollectTrash;
    private int _currentBlockSize;

    private void Awake()
    {
        _trash = new Queue<ITrash>();
    }

    private void OnEnable()
    {
        _timer.Completed += OnTimerCompleted;
        _dropTrigger.Entered += OnDropTriggerEntered;
        _dropTrigger.Exit += OnDropTriggerExit;
    }

    private void OnDisable()
    {
        _timer.Completed -= OnTimerCompleted;
        _dropTrigger.Entered -= OnDropTriggerEntered;
        _dropTrigger.Exit -= OnDropTriggerExit;
    }

    private void Start()
    {
        StartCoroutine(RecyclingProcess());
    }

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
                trash.transform.DOScale(Vector3.zero, 4f);
                trash.transform.DOJump(_trashContainer.transform.position, 4f, 1, 1.5f)
                    .OnComplete(() =>
                    {
                        trash.Release();
                        trash.transform.DOComplete(true);
                        _trash.Enqueue(trash);
                    });               
            }

            yield return Yielder.WaitForSeconds(0.3f);
        }
    }

    private IEnumerator RecyclingProcess()
    {
        const float Duration = 3f;

        while (true)
        {
            yield return new WaitUntil(() => _trash.Count > 0);

            var trash = _trash.Dequeue();
            _currentBlockSize += trash.Weight;
            
            if (_currentBlockSize >= _trashWeightToCreateBlock)
            {
                _currentBlockSize -= _trashWeightToCreateBlock; 
                _timer.Begin(Duration);
                yield return Yielder.WaitForSeconds(Duration);
            }

            yield return null;
        }
    }

    private void CreateBlock()
    {
        _skin.ShakeBox();

        ITrashBlock block = Instantiate(_trashBlockTemplate, transform.position, Quaternion.identity);
        _conveyor.Add(block);
    }
}
