using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;

    private void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.position = Vector2.zero;
    }

    private void FixedUpdate()
    {
        float moveX = Mathf.Clamp(Input.GetAxisRaw("Mouse X"), -1f, 1f);
        float moveY = Mathf.Clamp(Input.GetAxisRaw("Mouse Y"), -1f, 1f);
        movement = new Vector2(moveX, moveY);

        // Apply movement
        rb.AddForce(movement * speed, ForceMode2D.Impulse);

        // Flip sprite based on horizontal movement
        if (moveX > 0)
            spriteRenderer.flipX = false;
        else if (moveX < 0)
            spriteRenderer.flipX = true;
    }
}
