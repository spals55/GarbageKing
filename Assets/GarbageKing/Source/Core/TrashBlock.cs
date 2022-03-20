using UnityEngine;

public class TrashBlock : MonoBehaviour, ITrashBlock
{
    public void Release()
    {
        gameObject.SetActive(false);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
