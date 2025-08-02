using System.Collections.Generic;
using UnityEngine;

public static class InventorySaveSystem
{
    private static List<InventoryItemModel> savedItems = new();

    public static void Save(List<CollectibleDataSO> collectedItems)
    {
        savedItems.Clear();

        // Instead of one model per item, count quantities
        Dictionary<string, InventoryItemModel> itemMap = new();

        foreach (var item in collectedItems)
        {
            if (itemMap.ContainsKey(item.itemID))
            {
                itemMap[item.itemID].quantity++;
            }
            else
            {
                itemMap[item.itemID] = new InventoryItemModel(item, 1);
            }
        }

        savedItems.AddRange(itemMap.Values);
        Debug.Log($"[InventorySaveSystem] Saved {savedItems.Count} unique items.");
    }

    public static List<InventoryItemModel> Load()
    {
        foreach (var model in savedItems)
        {
            model.LoadItemData();
        }

        return new List<InventoryItemModel>(savedItems);
    }
}
