using UnityEngine;

public class MobileInputService : InputService
{
    public override Vector2 Axis => SimpleInputAxis();

    private Vector2 SimpleInputAxis() =>
        new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
}
