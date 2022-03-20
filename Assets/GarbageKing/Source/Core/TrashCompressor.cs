using System.Collections;
using UnityEngine;

public class TrashCompressor : TrashRecycler
{
    [SerializeField] private TrashConveyor _conveyor;
    [SerializeField] private TrashRecyclerSkin _skin;
    [SerializeField] private float _creatingBlockTime;

    protected override void CreateBlock()
    {
        _skin.ShakeBox();

        ITrashBlock block = Instantiate(TrashBlockTemplate, transform.position, Quaternion.identity);
       _conveyor.Add(block);
    }

    protected override IEnumerator RecyclingProcess()
    {
        {
            while (true)
            {
                yield return new WaitUntil(() => TrashQueue.Count > 0);

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
