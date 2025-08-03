using System;

public static class IslandEvents
{
    public static event Action OnIslandUpdated;
    public static event Action<CollectibleDataSO> OnStoreItemToIsland;

    public static void RaiseIslandUpdated()
    {
        OnIslandUpdated?.Invoke();
    }

    public static void RaiseStoreItemToIsland(CollectibleDataSO item)
    {
        OnStoreItemToIsland?.Invoke(item);
    }
}
