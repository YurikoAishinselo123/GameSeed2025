using UnityEngine;
public class EnemyDetectionManager : MonoBehaviour
{
    GameObject target;
    Rigidbody2D rb;
    float rotationspeed = 5f; 
    float speed = 7f;
    public bool isLeft;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.transform.position) < 5)
        {          
            Vector2 offset = target.transform.position - transform.position;
            if (isLeft)
            {
                transform.right = offset;
            }
            else
            {
                transform.right = -offset;
            }
            Vector2 chaseTarget = Vector2.MoveTowards(rb.position, target.transform.position, speed * Time.fixedDeltaTime);
            rb.MovePosition(chaseTarget);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, rotationspeed * Time.fixedDeltaTime);
        }
    }
}
