using UnityEngine;

public class StandaloneInputService : Input
{
    public override Vector2 Axis => UnityInputAxis();

    private Vector2 UnityInputAxis() =>
        new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Horizontal));
}
