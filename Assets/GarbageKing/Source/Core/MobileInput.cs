using UnityEngine;

public class MobileInput : IPlayerInput
{
    private readonly IInput _inputService;
    private readonly IControlledCharacter _controlled;

    private Vector3 _direction;

    public MobileInput(IInput inputService, IControlledCharacter controlled)
    {
        _inputService = inputService;
        _controlled = controlled;

        _direction = new Vector3();
    }

    public void FixedUpdateLogic(float tick)
    {
        if (_inputService.Axis.magnitude > Constants.Math.Epsilon)
        {
            _direction.x = _inputService.Axis.x;
            _direction.z = _inputService.Axis.y;

           _controlled.Move(_direction);
        }
    }
}
