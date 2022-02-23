using UnityEngine;

public interface ITrash
{
    TrashType Type { get; }
    bool CanCollect { get; }
    Transform transform { get; }
    void Show();
    void Hide();
    void Collect();
    void Release();
}

public enum TrashType
{
    Bottle,
    PizzaBox,
    Apple
}