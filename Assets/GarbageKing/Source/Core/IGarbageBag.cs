public interface IGarbageBag
{
    bool HasTrash { get; }

    bool CanAdd(int weight);
    void Add(ITrash trash);
    ITrash Get();
}