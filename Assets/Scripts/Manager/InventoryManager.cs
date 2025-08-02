using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private readonly List<CollectibleDataSO> inventory = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Optional: persist between scenes
    }

    /// <summary>
    /// Adds a collectible item to the inventory.
    /// </summary>
    /// <param name="item">The CollectibleDataSO asset to add.</param>
    public void Add(CollectibleDataSO item)
    {
        inventory.Add(item);
        InventorySaveSystem.Save(inventory); // ✅ Save dulu
        InventoryEvents.RaiseItemCollected(item);
        InventoryEvents.RaiseInventoryUpdated();
        Debug.Log($"Collected: {item.itemName}");
    }

    /// <summary>
    /// Returns the current list of collected items.
    /// </summary>
    public List<CollectibleDataSO> GetItems()
    {
        return inventory;
    }
}