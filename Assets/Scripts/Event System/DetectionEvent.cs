using System;

public static class DetectionEvents
{
    public static event Action OnDetect;
    public static event Action OnDetectCleared;

    public static void RaiseDetect()
    {
        OnDetect?.Invoke();
    }

    public static void RaiseDetectCleared()
    {
        OnDetectCleared?.Invoke();
    }
}