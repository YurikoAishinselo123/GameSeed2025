// Folder: ScriptableObject/
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Collectible Data")]
public class CollectibleDataSO : ScriptableObject
{
    public string itemID;
    public string itemName;
    public Sprite icon;
}
