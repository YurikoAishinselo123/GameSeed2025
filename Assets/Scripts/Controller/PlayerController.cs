using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the player
    public int currentHealth; // Current health of the player
    public HealthBar healthBar; // Reference to the HealthBar script
    float speed = 100f;
    float moveX;
    float moveXClamp;
    float moveY;
    float moveYClamp;
    Rigidbody2D rb;
    Vector2 movement;

    private void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
        rb.position = new Vector2(0, 0);
        currentHealth = maxHealth; // Initialize current health to maximum health
        healthBar.SetMaxHealth(maxHealth); // Set the maximum health in the health bar

    }
    void FixedUpdate()
    {
        //Vector3 desiredPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothedSpeed);
        //transform.position = smoothedPosition;
        moveX = Input.GetAxisRaw("Mouse X");
        //if(moveX > 0)
        //{
        //    moveXClamp = 1f;
        //}
        //else if(moveX < 0)
        //{
        //    moveXClamp = -1f;
        //}
        //else if(moveX == 0)
        //{
        //    moveXClamp = 0f;
        //}
        moveY = Input.GetAxisRaw("Mouse Y");
        //if (moveY > 0)
        //{
        //    moveYClamp = 1f;
        //}
        //else if (moveY < 0)
        //{
        //    moveYClamp = -1f;
        //}
        //else if(moveY == 0)
        //{
        //    moveYClamp = 0f;
        //}
        movement = new Vector2(moveX, moveY);
        rb.AddForce(movement * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        Debug.Log(movement);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce current health by damage amount
        healthBar.SetHealth(currentHealth); // Update the health bar with the new health value
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                TakeDamage(enemy.GetDamage());
            }
        }
    }
}

