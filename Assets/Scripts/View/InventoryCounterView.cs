using TMPro;
using UnityEngine;

public class InventoryCounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectedText;

    private void OnEnable()
    {
        InventoryEvents.OnInventoryUpdated += UpdateText;
        UpdateText(); // Refresh on start
    }

    private void OnDisable()
    {
        InventoryEvents.OnInventoryUpdated -= UpdateText;
    }

    private void UpdateText()
    {
        int count = InventorySaveSystem.Load().Count;
        collectedText.text = $"Collected: {count} item{(count == 1 ? "" : "s")}";
    }
}