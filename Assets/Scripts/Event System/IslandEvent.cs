using System;

public static class IslandEvents
{
    public static Action OnIslandUpdated;

    public static void RaiseIslandUpdated()
    {
        OnIslandUpdated?.Invoke();
    }
}
