using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawnManager : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private List<CollectibleDataSO> garbageList; // Your SO list with prefab & name
    private float spawnInterval = 6f;
    private float spawnY = 5f;
    private float minX = -35f;
    private float maxX = 35f;
    private int maxGarbageCount = 8;

    private float timer;
    private List<GameObject> activeGarbages = new();

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && activeGarbages.Count < maxGarbageCount)
        {
            timer = 0f;
            SpawnGarbage();
        }

        // Clean up destroyed garbage from list
        activeGarbages.RemoveAll(go => go == null);
    }

    private void SpawnGarbage()
    {
        if (garbageList == null || garbageList.Count == 0) return;

        // Pick a random garbage type
        var garbageData = garbageList[Random.Range(0, garbageList.Count)];

        // Instantiate at random X and fixed Y
        Vector2 spawnPos = new Vector2(Random.Range(minX, maxX), spawnY);
        GameObject garbage = Instantiate(garbageData.prefab, spawnPos, Quaternion.identity);

        activeGarbages.Add(garbage);
    }
}
