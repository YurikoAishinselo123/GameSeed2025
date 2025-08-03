using UnityEngine;

public class SchoolFishController : MonoBehaviour
{
    Rigidbody2D rb;
    float speed;
    PlayerController playerController;
    float slowedMovement = 0.001f;
    float originalSpeed;
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //originalSpeed = playerController.smoothedSpeed;
        speed = Random.Range(1f, 3f);
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (Vector2)transform.right * speed * Time.fixedDeltaTime);
        //Debug.Log(playerController.smoothedSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //playerController.smoothedSpeed = slowedMovement;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //playerController.smoothedSpeed = originalSpeed;

        }
    }

}
