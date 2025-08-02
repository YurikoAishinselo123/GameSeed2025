using UnityEngine;

public class DetectionManager : MonoBehaviour
{
    [Header("Detection Settings")]
    private float detectionRange = 1f;
    private float detectionFrequency = 0.1f;
    private int rayCount = 5;
    private float detectionAngle = 45f;
    [SerializeField] private LayerMask detectableLayer;

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
        Vector2 baseDirection = playerTransform.right; // Use .up if your sprite faces up

        for (int i = 0; i < rayCount; i++)
        {
            float angleOffset = startAngle + (step * i);
            float angleRad = Mathf.Deg2Rad * angleOffset;
            Vector2 rotatedDirection = new Vector2(
                baseDirection.x * Mathf.Cos(angleRad) - baseDirection.y * Mathf.Sin(angleRad),
                baseDirection.x * Mathf.Sin(angleRad) + baseDirection.y * Mathf.Cos(angleRad)
            );

            RaycastHit2D hit = Physics2D.Raycast(origin, rotatedDirection, detectionRange, detectableLayer);
            Debug.DrawRay(origin, rotatedDirection * detectionRange, hit.collider ? Color.green : Color.red, 0.1f);

            if (hit.collider != null)
            {
                IDetectable detectable = hit.collider.GetComponent<IDetectable>();
                if (detectable != null)
                {
                    currentDetected = detectable;
                    // Debug.Log($"[DetectionManager2D] ✅ Detected object: {hit.collider.name}");
                    detectable.Interact();
                    return;
                }
                else
                {
                    // Debug.Log($"[DetectionManager2D] ❌ No IDetectable on {hit.collider.name} (Layer: {LayerMask.LayerToName(hit.collider.gameObject.layer)})");
                }
            }
        }

        // Debug.Log("[DetectionManager2D] ❌ No detectable object found");
    }

    public IDetectable GetCurrentDetected()
    {
        return currentDetected;
    }
}