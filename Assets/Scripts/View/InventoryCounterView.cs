using TMPro;
using UnityEngine;
using System.Linq;

public class InventoryCounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectedText;

    private void OnEnable()
    {
        InventoryEvents.OnInventoryUpdated += UpdateText;

        // Always start at zero when gameplay begins
        collectedText.text = "Collected: 0 items";

        // Refresh with loaded values (in-memory only)
        UpdateText();
    }

    // void Update()
    // {
    //     Debug.Log("Item : " + coun)
    // }

    private void OnDisable()
    {
        InventoryEvents.OnInventoryUpdated -= UpdateText;
    }

    // private void UpdateText()
    // {
    //     var items = InventorySaveSystem.Load();
    //     int count = items.Count;
    //     Debug.Log("Item : " + count);

    //     collectedText.text = $"Collected: {count} item{(count == 1 ? "" : "s")}";
    // }

    private void UpdateText()
    {
        var items = InventorySaveSystem.Load();
        int totalQuantity = items.Sum(item => item.quantity); // Total collected
        collectedText.text = $"Collected: {totalQuantity} item{(totalQuantity == 1 ? "" : "s")}";
        Debug.Log("Item : " + totalQuantity);
    }
}
