using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerController : MonoBehaviour
{
    float speed = 4f;
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

    }
    void FixedUpdate()
    {
        moveX = Input.GetAxisRaw("Mouse X");
        moveXClamp = Mathf.Clamp(moveX, -1f, 1f);
        moveY = Input.GetAxisRaw("Mouse Y");
        moveYClamp = Mathf.Clamp(moveY, -1f, 1f);
        movement = new Vector2(moveXClamp, moveYClamp);
        rb.AddForce(movement * speed, ForceMode2D.Impulse);
        Debug.Log(movement);
    }
}