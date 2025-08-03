using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 targetPosition1;
    public Vector2 targetPosition2;
    public Vector2 targetPosition3;
    Vector2 currentPosition;
    float speed = 5f;

    enum MoveState { MovingToFirst, MovingToSecond, MovingToThird, Done }
    MoveState currentState;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentState = MoveState.MovingToFirst;
        currentPosition = rb.position;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        switch (currentState)
        {
            case MoveState.MovingToFirst:
                StartCoroutine(MoveToTarget(targetPosition1));
                if (Vector2.Distance(rb.position, currentPosition + targetPosition1) < 0.1f)
                {
                    currentPosition = rb.position;
                    currentState = MoveState.MovingToSecond;
                }
                break;

            case MoveState.MovingToSecond:
                StartCoroutine(MoveToTarget(targetPosition2));
                if (Vector2.Distance(rb.position, currentPosition + targetPosition2) < 0.1f)
                {
                    currentPosition = rb.position;
                    currentState = MoveState.MovingToThird;
                }
                break;


            case MoveState.MovingToThird:
                StartCoroutine(MoveToTarget(targetPosition3));
                if (Vector2.Distance(rb.position, currentPosition + targetPosition3) < 0.1f)
                {
                    currentPosition = rb.position;
                    currentState = MoveState.Done;
                }
                break;

            case MoveState.Done:
                Destroy(gameObject);
                break;
        }
    }
    IEnumerator MoveToTarget(Vector2 target)
    {
        yield return new WaitForSeconds(2f);
        Vector2 newPosition = Vector2.MoveTowards(rb.position, currentPosition + target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
    }
}
