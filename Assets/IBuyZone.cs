using System;

public interface IBuyZone
{
    event Action Unlocked;

    void Show();
    void Hide();
}