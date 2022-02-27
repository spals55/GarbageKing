using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashRecycler : Commodity, ITrashRecycler
{
    [SerializeField] private Timer _timer;
    [SerializeField] private int _trashToCreateBlock;
    [SerializeField] private TrashBlock _trashBlockTemplate;
    [SerializeField] private TrashConveyor _conveyor;
    [SerializeField] private TrashRecyclerSkin _skin;
    [SerializeField] private DropTrigger _dropTrigger;
    [SerializeField] private Transform _trashContainer;

    private Queue<ITrash> _trash = new Queue<ITrash>();
    private Coroutine _tryCollectTrash;
    private int _currentBlockSize;

    private void OnEnable()
    {
        _timer.Completed += OnTimerCompleted;
        _dropTrigger.Entered += OnDropTriggerEntered;
        _dropTrigger.Exit += OnDropTriggerExit;
    }

    private void OnTimerCompleted()
    {
        CreateBlock();
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

    public override void Show(bool animate)
    {
        _skin.Show(animate);
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
            
            if (_currentBlockSize > _trashToCreateBlock)
            {
                _currentBlockSize = 0;
                _timer.Begin(Duration);
                yield return new WaitForSeconds(Duration);
            }

            yield return null;
        }
    }

    private void CreateBlock()
    {
        _skin.ShakeBox(2.5f);

        ITrashBlock block = Instantiate(_trashBlockTemplate, transform.position, Quaternion.identity);
        _conveyor.Add(block);
    }
}
