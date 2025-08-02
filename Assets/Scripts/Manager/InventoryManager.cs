using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [SerializeField] private int maxInventorySize = 10;

    private readonly List<CollectibleDataSO> inventory = new();

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
    /// Attempts to add an item. Returns true if added successfully, false if inventory is full.
    /// </summary>
    public bool Add(CollectibleDataSO item)
    {
        if (inventory.Count >= maxInventorySize)
        {
            Debug.Log("[InventoryManager] Inventory full, cannot add item.");
            return false;
        }

        inventory.Add(item);
        InventorySaveSystem.Save(inventory);
        InventoryEvents.RaiseItemCollected(item);
        InventoryEvents.RaiseInventoryUpdated();
        Debug.Log($"Collected: {item.itemName}");
        return true;
    }

    /// <summary>
    /// Returns the list of currently collected items.
    /// </summary>
    public List<CollectibleDataSO> GetItems()
    {
        return inventory;
    }

    /// <summary>
    /// Returns how many items are currently collected.
    /// </summary>
    public int GetCount()
    {
        return inventory.Count;
    }

    /// <summary>
    /// Returns the maximum number of items the inventory can hold.
    /// </summary>
    public int GetCapacity()
    {
        return maxInventorySize;
    }

    /// <summary>
    /// Clears the entire inventory.
    /// </summary>
    public void Clear()
    {
        inventory.Clear();
        InventoryEvents.RaiseInventoryUpdated();
        Debug.Log("[InventoryManager] Inventory cleared.");
    }
}
