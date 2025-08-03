using System;
using UnityEngine;

public static class DetectionEvents
{
    public static event Action OnDetect;
    public static event Action OnDetectCleared;
    public static event Action<Vector2> OnDirectionChanged;

    public static void RaiseDetect() => OnDetect?.Invoke();
    public static void RaiseDetectCleared() => OnDetectCleared?.Invoke();
    public static void RaiseDirectionChanged(Vector2 direction) => OnDirectionChanged?.Invoke(direction);
}
