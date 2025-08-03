using UnityEngine;

public class CollectibleObject : MonoBehaviour, IDetectable
{
    [SerializeField] private CollectibleDataSO itemData;
    PlayerController playerController;
    GameObject Player;
    Vector3 addScale;
    private void Start()
    {
        addScale = new Vector3(0.02f, 0.02f, 0.02f);
        Player = GameObject.FindGameObjectWithTag("Player");
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
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
            Player.transform.localScale += addScale;
            playerController.speed -= 0.5f;
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
