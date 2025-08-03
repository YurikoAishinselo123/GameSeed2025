using System;

public static class InventoryEvents
{
    public static event Action<CollectibleDataSO> OnItemCollected;
    public static event Action OnInventoryUpdated;
    public static event Action<CollectibleDataSO> OnInventoryFull;

    // ✅ Request to add an item
    public static event Func<CollectibleDataSO, bool> OnAddItemRequested;

    public static void RaiseItemCollected(CollectibleDataSO data) => OnItemCollected?.Invoke(data);
    public static void RaiseInventoryUpdated() => OnInventoryUpdated?.Invoke();
    public static void RaiseInventoryFull(CollectibleDataSO data) => OnInventoryFull?.Invoke(data);

    public static bool RequestAddItem(CollectibleDataSO item)
    {
        return OnAddItemRequested?.Invoke(item) ?? false;
    }
}
