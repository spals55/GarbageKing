public interface IZone
{
    public string GUID { get; }

    void Buy(bool animate, bool save);
    public void Hide();
    public void Show();
}