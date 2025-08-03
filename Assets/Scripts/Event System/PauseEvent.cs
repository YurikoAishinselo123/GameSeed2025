using System;

public static class PauseEvents
{
    public static Action OnPauseRequested;

    public static void RaisePause()
    {
        OnPauseRequested?.Invoke();
    }
}
