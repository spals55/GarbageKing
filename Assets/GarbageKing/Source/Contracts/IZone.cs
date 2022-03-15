public interface IZone
{
    public string GUID { get; }

    void Buy(bool animate);
    public void Hide();
    public void Show();
}