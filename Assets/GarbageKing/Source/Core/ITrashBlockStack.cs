public interface ITrashBlockStack
{
    bool CanGet { get; }

    ITrashBlock Get();
}