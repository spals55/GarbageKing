public interface IZone
{
    public string GUID { get; }

    void Unlock(bool animate);
    public void Hide();
    public void Show();
}