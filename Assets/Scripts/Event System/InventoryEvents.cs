using System;

public static class InventoryEvents
{
    public static event Action<CollectibleDataSO> OnItemCollected;
    public static event Action OnInventoryUpdated; // ✅ For UI refresh

    public static void RaiseItemCollected(CollectibleDataSO data)
    {
        OnItemCollected?.Invoke(data);
    }

    public static void RaiseInventoryUpdated()
    {
        OnInventoryUpdated?.Invoke();
    }
}
