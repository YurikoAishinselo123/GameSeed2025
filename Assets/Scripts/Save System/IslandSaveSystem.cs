using System.Collections.Generic;
using UnityEngine;

public static class IslandSaveSystem
{
    private static List<string> storedItemIDs = new();

    public static void Save(List<CollectibleDataSO> items)
    {
        storedItemIDs.Clear();
        foreach (var item in items)
        {
            storedItemIDs.Add(item.itemID);
        }
    }

    public static List<CollectibleDataSO> Load()
    {
        List<CollectibleDataSO> loaded = new();
        foreach (var id in storedItemIDs)
        {
            var item = InventoryDatabaseService.GetItemByID(id);
            if (item != null)
                loaded.Add(item);
        }
        return loaded;
    }
}
