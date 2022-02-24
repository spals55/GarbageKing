using UnityEngine;

public interface IMovement
{
    bool Stopped { get; }

    void Move(Vector3 direction);
}
