using UnityEngine;

public class GarbageBag : MonoBehaviour
{
    public void Add(ITrash trash)
    {
        trash.Hide();
    }

    public void Remove(ITrash trash)
    {
        trash.Show();
    }
}