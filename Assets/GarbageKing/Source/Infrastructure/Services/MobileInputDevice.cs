﻿using UnityEngine;

public class MobileInputDevice : InputDevice
{
    public override Vector2 Axis => SimpleInputAxis();

    private Vector2 SimpleInputAxis() =>
        new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
}
