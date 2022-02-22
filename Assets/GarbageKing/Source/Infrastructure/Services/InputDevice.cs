using UnityEngine;

public abstract class Input : IInputDevice
{
    protected const string Horizontal = nameof(Horizontal);
    protected const string Vertical = nameof(Vertical);

    public abstract Vector2 Axis { get; }
}
