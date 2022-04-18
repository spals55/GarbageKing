using System;

public interface IGarbageBag
{
    bool HasTrash { get; }
    int Weight { get; }
    int MaxWeight { get; }

    event Action WeightChanged;

    bool CanAdd(int weight);
    void Add(Trash trash);
    Trash GetTrash();
}