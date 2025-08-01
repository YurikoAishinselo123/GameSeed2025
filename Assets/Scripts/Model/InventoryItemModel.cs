[System.Serializable]
public class InventoryItemModel
{
    public string itemID;
    public int quantity;

    [System.NonSerialized]
    public CollectibleDataSO itemSO;

    public InventoryItemModel(CollectibleDataSO itemSO, int quantity = 1)
    {
        this.itemSO = itemSO;
        this.itemID = itemSO.itemID;
        this.quantity = quantity;
    }

    public void LoadItemData()
    {
        itemSO = InventoryDatabaseService.GetItemByID(itemID);
    }
}
