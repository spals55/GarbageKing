using System;

public interface ITimer
{
    event Action Completed;

    void Begin(float seconds);
    void Stop();
}