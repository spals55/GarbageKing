using UnityEngine;

public abstract class InputService : IInput
{
    protected const string Horizontal = nameof(Horizontal);
    protected const string Vertical = nameof(Vertical);

    public abstract Vector2 Axis { get; }
}
