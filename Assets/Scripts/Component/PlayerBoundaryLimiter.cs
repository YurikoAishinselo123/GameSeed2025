using UnityEngine;

[RequireComponent(typeof(Transform))]
public class PlayerBoundaryLimiter : MonoBehaviour
{
    [Header("Boundary Area")]
    [SerializeField] private Vector2 minBounds = new Vector2(-10f, -4.5f); 
    [SerializeField] private Vector2 maxBounds = new Vector2(10f, 4.5f); 

    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = transform;
    }

    private void LateUpdate()
    {
        ClampPosition();
    }

    private void ClampPosition()
    {
        Vector3 clampedPosition = playerTransform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minBounds.x, maxBounds.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minBounds.y, maxBounds.y);

        playerTransform.position = clampedPosition;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        // Visualize the clamping bounds in the scene view
        Gizmos.color = Color.green;
        Vector3 center = (minBounds + maxBounds) / 2f;
        Vector3 size = new Vector3(maxBounds.x - minBounds.x, maxBounds.y - minBounds.y, 0f);
        Gizmos.DrawWireCube(center, size);
    }
#endif
}
