using UnityEngine;

public class CollectibleObject : MonoBehaviour, IDetectable
{
    [SerializeField] private CollectibleDataSO itemData;

    private void OnEnable()
    {
        InventoryEvents.OnInventoryFull += HandleInventoryFull;
    }

    private void OnDisable()
    {
        InventoryEvents.OnInventoryFull -= HandleInventoryFull;
    }

    public void Interact()
    {
        // ✅ Actually attempt to add it first
        bool added = InventoryManager.Instance.Add(itemData);

        if (added)
        {
            // ✅ Item was successfully added, so we can safely destroy this object
            Destroy(gameObject);
        }
    }

    private void HandleInventoryFull(CollectibleDataSO fullItem)
    {
        if (fullItem == itemData)
        {
            IslandEvents.RaiseStoreItemToIsland(itemData);
        }
    }
}
