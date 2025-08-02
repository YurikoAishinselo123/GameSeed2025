using UnityEngine;

public class DetectionManager : MonoBehaviour
{
    [Header("Detection Settings")]
    private float detectionRange = 1f;
    private float detectionFrequency = 0.1f;
    private int rayCount = 5;
    private float detectionAngle = 45f;
    [SerializeField] private LayerMask detectableLayer;
    [SerializeField] private LayerMask islandLayer;

    [Header("Reference")]
    [SerializeField] private Transform playerTransform;

    private float timer;
    private IDetectable currentDetected;

    private void Start()
    {
        if (playerTransform == null)
            playerTransform = transform; // Default to this GameObject's transform
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= detectionFrequency)
        {
            timer = 0f;
            PerformDetection();
        }
    }

    private void OnEnable()
    {
        InteractionEvents.OnInteract += HandleInteract;
    }

    private void OnDisable()
    {
        InteractionEvents.OnInteract -= HandleInteract;
    }

    private void HandleInteract()
    {
        TryInteractWithCurrentTarget();
    }

    private void TryInteractWithCurrentTarget()
    {
        if (currentDetected != null)
        {
            currentDetected.Interact();
        }
    }

    private void PerformDetection()
    {
        currentDetected = null;

        float step = detectionAngle / (rayCount - 1);
        float startAngle = -detectionAngle / 2f;
        Vector2 origin = playerTransform.position;
        Vector2 baseDirection = playerTransform.right;

        for (int i = 0; i < rayCount; i++)
        {
            float angleOffset = startAngle + (step * i);
            float angleRad = Mathf.Deg2Rad * angleOffset;

            Vector2 rotatedDirection = new Vector2(
                baseDirection.x * Mathf.Cos(angleRad) - baseDirection.y * Mathf.Sin(angleRad),
                baseDirection.x * Mathf.Sin(angleRad) + baseDirection.y * Mathf.Cos(angleRad)
            );

            // First: Detect Collectibles
            RaycastHit2D hit = Physics2D.Raycast(origin, rotatedDirection, detectionRange, detectableLayer);
            if (hit.collider != null)
            {
                IDetectable detectable = hit.collider.GetComponent<IDetectable>();
                if (detectable != null)
                {
                    currentDetected = detectable;
                    detectable.Interact();
                    return;
                }
            }

            // Second: Detect Island
            RaycastHit2D islandHit = Physics2D.Raycast(origin, rotatedDirection, detectionRange, islandLayer);
            if (islandHit.collider != null)
            {
                Debug.Log($"Island Detected: {islandHit.collider.name}");
                IslandManager.Instance.StoreAllFromInventory();
                return;
            }
        }
    }

    public IDetectable GetCurrentDetected()
    {
        return currentDetected;
    }
}