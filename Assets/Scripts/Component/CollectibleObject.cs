using UnityEngine;

// public class CollectibleObject : MonoBehaviour, IDetectable
// {
//     [SerializeField] private CollectibleDataSO itemData;

//     public void Interact()
//     {
//         if (itemData != null)
//         {
//             InventoryManager.Instance.Add(itemData);
//             Debug.Log($"[CollectibleObject] Collected: {itemData.itemName}");
//             Destroy(gameObject);
//         }
//     }
// }

public class CollectibleObject : MonoBehaviour, IDetectable
{
    [SerializeField] private CollectibleDataSO itemData;

    public void Interact()
    {
        bool added = InventoryManager.Instance.Add(itemData);
        if (!added)
        {
            IslandManager.Instance.Store(itemData);
        }

        Destroy(gameObject);
    }
}
