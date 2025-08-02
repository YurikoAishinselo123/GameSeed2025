using TMPro;
using UnityEngine;

public class IslandCounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI islandText;

    private void OnEnable()
    {
        IslandEvents.OnIslandUpdated += UpdateText;
        UpdateText();
    }

    private void OnDisable()
    {
        IslandEvents.OnIslandUpdated -= UpdateText;
    }

    private void UpdateText()
    {
        var island = IslandManager.Instance;
        if (island == null)
        {
            islandText.text = "Island: 0 items";
            return;
        }

        int count = island.GetCount();
        islandText.text = $"Island: {count} item{(count == 1 ? "" : "s")}";
    }
}
