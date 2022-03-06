public interface IRegion
{
    string GUID { get; }

    void Unlock(bool animate);
}
