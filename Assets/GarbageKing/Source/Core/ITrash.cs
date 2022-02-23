using UnityEngine;

public interface ITrash
{
    TrashType Type { get; }
    bool CanCollect { get; }
    Transform transform { get; }
    int Weight { get; }

    void Show();
    void Hide();
    void Collect();
    void Release();
}
