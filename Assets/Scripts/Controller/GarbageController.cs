using UnityEngine;

public class GarbageController : MonoBehaviour
{
    [SerializeField] private float sinkSpeed = 1f;
    private float minDepth = -9f;
    private float maxDepth = -15f;

    private float targetY;

    private void Start()
    {
        targetY = Random.Range(minDepth, maxDepth);
    }

    private void Update()
    {
        if (transform.position.y > targetY)
        {
            transform.position += Vector3.down * sinkSpeed * Time.deltaTime;
        }
    }
}
