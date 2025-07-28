using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float smoothTime = 0.3f;

    [Header("Movement Boundaries (Optional)")]
    public bool useBoundaries = true;
    public Vector2 minBounds = new Vector2(-10f, -5f);
    public Vector2 maxBounds = new Vector2(10f, 5f);

    [Header("Animation Settings")]
    public bool flipSpriteBasedOnDirection = true;

    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;
    private SpriteRenderer spriteRenderer;
    private bool facingRight = true;

    void Start()
    {
        // Hide the cursor
        Cursor.visible = false;

        // Get references
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set initial target position to current position
        targetPosition = transform.position;
    }

    void Update()
    {
        HandleMovementInput();
        MoveTowardsTarget();
        HandleRotation();
        HandleSpriteFlipping();
    }

    void HandleMovementInput()
    {
        // Check if InputManager exists
        if (InputManager.Instance == null)
        {
            // Fallback to direct mouse input if InputManager is not available
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            worldPosition.z = transform.position.z;

            if (useBoundaries)
            {
                worldPosition.x = Mathf.Clamp(worldPosition.x, minBounds.x, maxBounds.x);
                worldPosition.y = Mathf.Clamp(worldPosition.y, minBounds.y, maxBounds.y);
            }

            targetPosition = worldPosition;
            return;
        }

        // Get mouse position from InputManager
        Vector2 mouseWorldPos = InputManager.Instance.GetMouseWorldPosition();

        // Apply boundaries if enabled
        if (useBoundaries)
        {
            mouseWorldPos.x = Mathf.Clamp(mouseWorldPos.x, minBounds.x, maxBounds.x);
            mouseWorldPos.y = Mathf.Clamp(mouseWorldPos.y, minBounds.y, maxBounds.y);
        }

        targetPosition = new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z);
    }

    void MoveTowardsTarget()
    {
        // Smooth movement towards target
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, moveSpeed);
    }

    void HandleRotation()
    {
        // Calculate direction to target
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Only rotate if we're moving
        if (direction.magnitude > 0.1f)
        {
            // Calculate rotation angle
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Create target rotation
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Smoothly rotate towards target
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void HandleSpriteFlipping()
    {
        if (!flipSpriteBasedOnDirection || spriteRenderer == null)
            return;

        // Check if we should flip the sprite based on movement direction
        Vector3 direction = targetPosition - transform.position;

        if (direction.x > 0 && !facingRight)
        {
            // Moving right, make sure sprite faces right
            facingRight = true;
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0 && facingRight)
        {
            // Moving left, flip sprite
            facingRight = false;
            spriteRenderer.flipX = true;
        }
    }

    // Optional: Draw boundaries in Scene view
    void OnDrawGizmosSelected()
    {
        if (useBoundaries)
        {
            Gizmos.color = Color.yellow;
            Vector3 center = new Vector3((minBounds.x + maxBounds.x) / 2, (minBounds.y + maxBounds.y) / 2, 0);
            Vector3 size = new Vector3(maxBounds.x - minBounds.x, maxBounds.y - minBounds.y, 0);
            Gizmos.DrawWireCube(center, size);
        }
    }

    // Public methods for checking movement state
    public Vector3 GetMovementDirection()
    {
        return (targetPosition - transform.position).normalized;
    }

    public float GetMovementSpeed()
    {
        return velocity.magnitude;
    }

    public bool IsMoving()
    {
        return Vector3.Distance(transform.position, targetPosition) > 0.1f;
    }
}