using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerController : MonoBehaviour
{
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
}

