using System.Collections;
using UnityEngine;

public class TrashShredder : TrashRecycler
{
    [SerializeField] private TrashShredderSkin _skin;
    [SerializeField] private TrashBlockStack _stack;
    [SerializeField] private float _creatingBlockTime;

    private TrashBlockPool _pool;

    private void Awake()
    {
        _pool = FindObjectOfType<TrashBlockPool>();
    }

    protected override void CreateBlock()
    {
        _skin.ShakeBox();

        ITrashBlock block = _pool.GetElement(transform.position);
        _stack.Add(block);

        _skin.StopRotatingBlades();
    }

    protected override IEnumerator RecyclingProcess()
    {
        {
            while (true)
            {
                yield return new WaitUntil(() => TrashQueue.Count > 0);

                _skin.StartRotatingBlades();
                var trash = TrashQueue.Dequeue();
                CurrentBlocksWeight += trash.Weight;

                if (CanCreateBlock)
                {
                    CurrentBlocksWeight -= TrashWeightToCreateBlock;
                    Timer.Begin(_creatingBlockTime);

                    yield return Yielder.WaitForSeconds(_creatingBlockTime);
                }

                yield return null;
            }
        }
    }
}