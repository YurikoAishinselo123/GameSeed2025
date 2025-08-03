using UnityEngine;

public class SpawnFishManager : MonoBehaviour
{
    [SerializeField] private FishDataSO[] fishTypes;
    [SerializeField] private Transform leftSpawnPoint;
    [SerializeField] private Transform rightSpawnPoint;

    private float spawnInterval = 5f;
    private float minY = -15f;
    private float maxY = 15f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnFish();
            timer = 0f;
        }
    }

    private void SpawnFish()
    {
        var data = fishTypes[Random.Range(0, fishTypes.Length)];

        SwimDirection direction = (Random.value > 0.5f) ? SwimDirection.LeftToRight : SwimDirection.RightToLeft;
        Vector3 spawnPos = (direction == SwimDirection.LeftToRight ? leftSpawnPoint.position : rightSpawnPoint.position);
        spawnPos.y = Random.Range(minY, maxY);

        var fish = Instantiate(data.fishPrefab, spawnPos, Quaternion.identity);

        // Optionally override sprite if prefab uses a placeholder sprite
        var sr = fish.GetComponent<SpriteRenderer>();
        if (sr != null && data.fishSprite != null)
            sr.sprite = data.fishSprite;

        var controller = fish.GetComponent<FishNPCController>();
        controller.Init(data.swimSpeed, direction);
    }

}
