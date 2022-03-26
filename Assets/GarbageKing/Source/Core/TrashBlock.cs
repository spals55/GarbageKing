using UnityEngine;

public class TrashBlock : PoolElement, ITrashBlock
{
    protected override void ResetScale()
    {
        transform.localScale = Vector3.one;
    }
}
