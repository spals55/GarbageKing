using System;

public interface IBuyZone
{
    int Id { get; }

    void Show();
    void Hide();
    void Unlock(bool animate);
}