using UnityEngine;

public abstract class InputDevice : IInputDevice
{
    protected const string Horizontal = nameof(Horizontal);
    protected const string Vertical = nameof(Vertical);

    public abstract Vector2 Axis { get; }
}
