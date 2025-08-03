using UnityEngine;

public class FishNPCController : MonoBehaviour
{
    private float speed;
    private Vector3 targetPosition;

    public void Init(float speed, SwimDirection direction)
    {
        this.speed = speed;

        float screenWidth = 40f; 
        float y = transform.position.y;

        if (direction == SwimDirection.LeftToRight)
            targetPosition = new Vector3(screenWidth, y, 0f);
        else
            targetPosition = new Vector3(-screenWidth, y, 0f);

        // Flip sprite if needed
        var sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
            sprite.flipX = direction == SwimDirection.RightToLeft;
    }

    private void Update()
    {
        // Move toward target
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Destroy if reached
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
