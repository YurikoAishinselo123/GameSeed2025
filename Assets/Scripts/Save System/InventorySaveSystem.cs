using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class InventorySaveSystem
{
    private static string path => Path.Combine(Application.persistentDataPath, "inventory.json");

    public static void Save(List<CollectibleDataSO> items)
    {
        List<string> itemIDs = new();
        foreach (var item in items)
        {
            if (!string.IsNullOrEmpty(item.itemID))
                itemIDs.Add(item.itemID);
        }

        var wrapper = new InventoryWrapper { itemIDs = itemIDs };
        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(path, json);
        Debug.Log($"[InventorySaveSystem] ✅ Inventory saved to: {path}");
    }

    public static List<CollectibleDataSO> Load()
    {
        if (!File.Exists(path))
        {
            Debug.Log("[InventorySaveSystem] ❌ No save file found.");
            return new List<CollectibleDataSO>();
        }

        string json = File.ReadAllText(path);
        var wrapper = JsonUtility.FromJson<InventoryWrapper>(json);

        List<CollectibleDataSO> loadedItems = new();
        foreach (string id in wrapper.itemIDs)
        {
            CollectibleDataSO item = InventoryDatabaseService.GetItemByID(id);
            if (item != null)
                loadedItems.Add(item);
            else
                Debug.LogWarning($"[InventorySaveSystem] ⚠️ Item ID '{id}' not found in database.");
        }

        Debug.Log($"[InventorySaveSystem] ✅ Loaded {loadedItems.Count} items.");
        return loadedItems;
    }

    [System.Serializable]
    private class InventoryWrapper
    {
        public List<string> itemIDs;
    }
}