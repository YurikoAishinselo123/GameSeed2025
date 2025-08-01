using System.Collections.Generic;
using UnityEngine;

public class InventoryDatabaseService : MonoBehaviour
{
    public static InventoryDatabaseService Instance { get; private set; }

    [SerializeField] private List<CollectibleDataSO> allItems;

    private Dictionary<string, CollectibleDataSO> lookup = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        foreach (var item in allItems)
        {
            if (!string.IsNullOrEmpty(item.itemID))
                lookup[item.itemID] = item;
        }
    }

    public static CollectibleDataSO GetItemByID(string id)
    {
        if (Instance.lookup.TryGetValue(id, out var item))
            return item;
        return null;
    }
}