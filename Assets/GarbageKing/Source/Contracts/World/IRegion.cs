public interface IRegion
{
    string Name { get; }

    void Unlock(bool animate);
}
