using System.Collections.Generic;
using UnityEngine;

public class IslandManager : MonoBehaviour
{
    public static IslandManager Instance { get; private set; }

    private readonly List<CollectibleDataSO> storedItems = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Store a single item into the island.
    /// </summary>
    public void Store(CollectibleDataSO item)
    {
        storedItems.Add(item);
        IslandSaveSystem.Save(storedItems);
        IslandEvents.RaiseIslandUpdated();
        Debug.Log($"[Island] Stored: {item.itemName}");
    }

    /// <summary>
    /// Moves all inventory items into the island and clears inventory.
    /// </summary>
    public void StoreAllFromInventory()
    {
        var items = InventoryManager.Instance.GetItems();
        foreach (var item in items)
        {
            storedItems.Add(item);
        }

        InventoryManager.Instance.Clear();

        // 🟢 Save the updated empty inventory
        InventorySaveSystem.Save(new List<CollectibleDataSO>());

        // 🟢 Save the island data too
        IslandSaveSystem.Save(storedItems);

        IslandEvents.RaiseIslandUpdated();
        InventoryEvents.RaiseInventoryUpdated(); 

        Debug.Log("[IslandManager] Stored all inventory items.");
    }


    /// <summary>
    /// Returns all stored items.
    /// </summary>
    public List<CollectibleDataSO> GetStoredItems()
    {
        return storedItems;
    }

    /// <summary>
    /// Returns how many items are stored on the island.
    /// </summary>
    public int GetCount()
    {
        return storedItems.Count;
    }
}
