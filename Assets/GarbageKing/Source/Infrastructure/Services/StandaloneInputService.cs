using UnityEngine;

public class StandaloneInputService : InputService
{
    public override Vector2 Axis => UnityInputAxis();

    private Vector2 UnityInputAxis() =>
        new Vector2(Input.GetAxis(Horizontal), Input.GetAxis(Horizontal));
}
