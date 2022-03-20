public interface IHandStack
{
    void Add(ITrashBlock stackable);
    ITrashBlock Get();
}