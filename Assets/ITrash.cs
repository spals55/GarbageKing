using UnityEngine;

public interface ITrash
{
    bool CanCollect { get; }
    Transform transform { get; }
    void Show();
    void Hide();
    void Collect();
    void Release();
}