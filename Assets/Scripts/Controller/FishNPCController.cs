using UnityEngine;

public class FishNPCController : MonoBehaviour
{
    Rigidbody2D rb;
    float speed;
    void Start()
    {
        speed = Random.Range(5f, 20f);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (Vector2)transform.right * speed * Time.fixedDeltaTime);
    }
}
