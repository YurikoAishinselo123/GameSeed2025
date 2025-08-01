using UnityEngine;

public class CollectibleObject : MonoBehaviour, IDetectable
{
    [SerializeField] private CollectibleDataSO itemData;

    public void Interact()
    {
        if (itemData != null)
        {
            InventoryManager.Instance.Add(itemData);
            Debug.Log($"[CollectibleObject] Collected: {itemData.itemName}");
            Destroy(gameObject);
        }
    }
}
