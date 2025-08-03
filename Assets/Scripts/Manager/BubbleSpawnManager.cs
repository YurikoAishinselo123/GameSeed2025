using UnityEngine;

public class BubbleSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject SpawnBubble;
    [SerializeField] GameObject BubbleWarning;
    Vector2 randomPosition;
    Vector2 getRandomPosition;
    float spawnWaitTime;
    void Start()
    {
        spawnWaitTime = Random.Range(3f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnWaitTime <= 0)
        {
            spawnWarningBubble();
            spawnWaitTime = Random.Range(3f, 5f);
        }
        else
        {
            spawnWaitTime -= Time.deltaTime;
        }
    }

    void spawnWarningBubble()
    {
        randomPosition = new Vector2(Random.Range(9f, -9f), -4.3f);
        getRandomPosition = randomPosition;
        GameObject SpawnedWarning = Instantiate(BubbleWarning, getRandomPosition, Quaternion.identity);
        Destroy(SpawnedWarning, 5);
        Invoke("SpawnTheBubble", 2f);
    }

    void SpawnTheBubble()
    {
        GameObject SpawnedBubble = Instantiate(SpawnBubble, getRandomPosition, Quaternion.identity);
        Destroy(SpawnedBubble, 5f);
    }
}
