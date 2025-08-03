using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    [SerializeField] GameObject[] Enemy;
    float spawnWaitTime;
    void Start()
    {
        spawnWaitTime = Random.Range(5f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnWaitTime <= 0)
        {
            SpawnEnemy();
            spawnWaitTime = Random.Range(5f, 10f);
        }
        else
        {
            spawnWaitTime -= Time.deltaTime;
        }
    }

    void SpawnEnemy()
    {
        float rightOrLeft = Random.Range(0f, 2f);
        if (rightOrLeft <= 1f)
        {
            Instantiate(Enemy[0], new Vector2(13f, Random.Range(4f, -4f)), Quaternion.identity);
        }
        else if (rightOrLeft >= 1f)
        {
            Instantiate(Enemy[1], new Vector2(-13f, Random.Range(4f, -4f)), Quaternion.identity);                
        }

    }
}
